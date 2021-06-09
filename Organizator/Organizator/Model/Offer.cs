using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    public class Offer: INotifyPropertyChanged
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

        private DateTime _dateTime;
        private string _place;
        private string _associateName;
        private int _price;

        public Offer(string place, string associateName, DateTime dateTime, int price)
        {
            _dateTime = dateTime;
            _associateName = associateName;
            _place = place;
            _price = price;
        }

        public string AssociateName
        {
            get
            {
                return _associateName;
            }
            set
            {
                if (value != _associateName)
                {
                    _associateName = value;
                    OnPropertyChanged("AssociateName");
                }
            }
        }

        public DateTime Time
        {
            get
            {
                return _dateTime;
            }
            set
            {
                if (value != _dateTime)
                {
                    _dateTime = value;
                    OnPropertyChanged("Time");
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
                if (value != _place)
                {
                    _place = value;
                    OnPropertyChanged("Place");
                }
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

    }
}
