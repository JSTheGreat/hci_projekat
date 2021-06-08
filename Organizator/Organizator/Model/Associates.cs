using System;
using System.Collections.Generic;
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
