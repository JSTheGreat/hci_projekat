using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    class Associate
    {

        public string name;
        public string place;
        public string type;
        public string number;

        public Associate(string name, string place, string type, string number)
        {
            this.name = name;
            this.number = number;
            this.place = place;
            this.type = type;
        }

    }
}
