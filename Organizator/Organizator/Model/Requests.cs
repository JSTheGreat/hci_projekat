using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Requests(ObservableCollection<Request> requests)
        {
            List<Request> list = new List<Request>();
            foreach (var r in requests)
            {
                list.Add(r);
            }
            this.requests = list;
        }

        public List<Request> byUser(string user)
        {
            List<Request> newList = new List<Request>();
            foreach(Request request in this.requests)
            {
                if (request.Organizer.Equals(user))
                    newList.Add(request);
            }
            return newList;
        }

        public void remove(ObservableCollection<Request> deleteList)
        {
            foreach(Request r in deleteList)
            {
                this.requests.Remove(r);
            }
        }

        internal List<Request> toList()
        {
            return this.requests;
        }

        public Request byClient(string client)
        {
            foreach(var r in requests)
            {
                if (r.Client.Equals(client))
                    return r;
            }
            return null;
        }
    }
}
