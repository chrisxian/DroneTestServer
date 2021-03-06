using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneTest.Master.Model
{
    public enum AgentJobStatus { BranchUpdating, Standby, Executing } 

    public class Agent
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public bool IsConnected { get; set; }
    }
}
