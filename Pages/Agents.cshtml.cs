using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DroneTest.Master.Hubs;
using DroneTest.Master.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DroneTest.Master.Pages
{
    public class AgentsModel : PageModel
    {
        public void OnGet()
        {
            //refresh agents list.
            Agents = MasterHub.ConnectedAgents.Values.ToList();
        }

        public IList<Agent> Agents { get; set; }
    }
}