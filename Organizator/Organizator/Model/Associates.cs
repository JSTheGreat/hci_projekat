using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    class Associates
    {

        private List<Associate> associates;

        public Associates(List<Associate> associates)
        {
            this.associates = associates;
        }

        public Associates(ObservableCollection<Associate> associates)
        {
            List<Associate> list = new List<Associate>();
            foreach(var a in associates)
            {
                list.Add(a);
            }
            this.associates = list;
        }

        public void addAssociate(Associate associate)
        {
            this.associates.Add(associate);
        }

        public List<Associate> toList()
        {
            return this.associates;
        }

    }
}
