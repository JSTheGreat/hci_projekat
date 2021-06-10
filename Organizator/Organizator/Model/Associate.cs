using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    public class Associate: INotifyPropertyChanged
    {

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _name;
        private string _place;
        private string _type;
        private string _number;

        public Associate(string name, string place, string type, string number)
        {
            this._name = name;
            this._number = number;
            this._place = place;
            this._type = type;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name && value != null && !value.Equals(""))
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value != _number && value != null && !value.Equals(""))
                {
                    _number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        public string Place
        {
            get
            {
                return _place;
            }
            set
            {
                if (value != _place && value != null && !value.Equals(""))
                {
                    _place = value;
                    OnPropertyChanged("Place");
                }
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value != _type && value != null && !value.Equals(""))
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

    }
}
