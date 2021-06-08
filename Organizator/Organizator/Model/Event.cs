using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    class Event
    {
        public DateTime dateTime;
        public string place;
        public string associateName;

        public Event(string place, string associateName, DateTime dateTime)
        {
            this.dateTime = dateTime;
            this.associateName = associateName;
            this.place = place;
        }
    }
}
