using System;
using System.Collections.Generic;
using System.Text;

namespace RequestRouter
{
    public class AgentOneRequest
    {
        public string BrokerName { get; set; }
        public int NumFriends { get; set; }
        public decimal RequestedCost { get; set; }
    }
}
