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
        private string _sender;
        private string _client;

        public Offer(string place, string associateName, DateTime dateTime, int price, string sender, string client)
        {
            _dateTime = dateTime;
            _associateName = associateName;
            _place = place;
            _price = price;
            _sender = sender;
            _client = client;
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

        public string Sender
        {
            get
            {
                return _sender;
            }
            set
            {
                if (value != _sender)
                {
                    _sender = value;
                    OnPropertyChanged("Sender");
                }
            }
        }

        public string Client
        {
            get
            {
                return _client;
            }
            set
            {
                if (value != _client)
                {
                    _client = value;
                    OnPropertyChanged("Client");
                }
            }
        }

    }
}
