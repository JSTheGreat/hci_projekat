using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    public class Request: INotifyPropertyChanged
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

        private string _client;
        private string _partyType;
        private DateTime _dateTime;
        private int _maxBudget;
        private string _organizer;
        private string _place;

        public Request(string client, string partyType, DateTime dateTime, string place, int maxBudget, string organizer)
        {
            _client = client;
            _dateTime = dateTime;
            _maxBudget = maxBudget;
            _partyType = partyType;
            _organizer = organizer;
            _place = place;
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

        public int MaxBudget
        {
            get
            {
                return _maxBudget;
            }
            set
            {
                if (value != _maxBudget)
                {
                    _maxBudget = value;
                    OnPropertyChanged("MaxBudget");
                }
            }
        }

        public string PartyType
        {
            get
            {
                return _partyType;
            }
            set
            {
                if (value != _partyType)
                {
                    _partyType = value;
                    OnPropertyChanged("PartyType");
                }
            }
        }

        public string Organizer
        {
            get
            {
                return _organizer;
            }
            set
            {
                if (value != _organizer)
                {
                    _organizer = value;
                    OnPropertyChanged("Organizer");
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
    }
}
