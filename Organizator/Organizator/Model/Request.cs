using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    class Request
    {

        public string client;
        public string partyType;
        public DateTime dateTime;
        public int maxBudget;
        public string organizer;
        public string place;

        public Request(string client, string partyType, DateTime dateTime, string place, int maxBudget, string organizer)
        {
            this.client = client;
            this.dateTime = dateTime;
            this.maxBudget = maxBudget;
            this.partyType = partyType;
            this.organizer = organizer;
            this.place = place;
        }

    }
}
