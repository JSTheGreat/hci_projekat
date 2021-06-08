using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    class Requests
    {

        private List<Request> requests;

        public Requests(List<Request> requests)
        {
            this.requests = requests;
        }

        public List<Request> byUser(string user)
        {
            List<Request> newList = new List<Request>();
            foreach(Request request in this.requests)
            {
                if (request.organizer.Equals(user))
                    newList.Add(request);
            }
            return newList;
        }

        public void remove(Request request)
        {
            this.requests.Remove(request);
        }
    }
}
