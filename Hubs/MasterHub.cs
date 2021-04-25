using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DroneTest.Master.Model;

using Microsoft.AspNetCore.SignalR;

namespace DroneTest.Master.Hubs
{
    public class MasterHub : Hub
    {
        public static readonly Dictionary<string, Agent> ConnectedAgents = new Dictionary<string, Agent>();

        public async Task SendMessage( string user, string message )
        {
            await Clients.All.SendAsync( "ReceiveMessage", user, message );
        }

        public override async Task OnConnectedAsync()
        {
            ConnectedAgents.Add( Context.ConnectionId, new Agent {Id = Context.ConnectionId, Status = "connected"} );

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync( Exception exception )
        {
            ConnectedAgents.Remove( Context.ConnectionId );
            await base.OnDisconnectedAsync( exception );
        }
    }
}