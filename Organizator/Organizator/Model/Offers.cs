using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.Model
{
    [Serializable]
    class Offers
    {

        private List<Offer> offers;

        public Offers(List<Offer> offers)
        {
            this.offers = offers;
        }

        public Offers(ObservableCollection<Offer> offers)
        {
            List<Offer> list = new List<Offer>();
            foreach (var r in offers)
            {
                list.Add(r);
            }
            this.offers = list;
        }

        public void addOffer(ObservableCollection<Offer> deleteList)
        {
            foreach (Offer r in deleteList)
            {
                this.offers.Add(r);
            }
        }

        internal List<Offer> toList()
        {
            return this.offers;
        }

        public bool offerExists(Offer offer)
        {
            foreach(var o in offers)
            {
                if (o.Place.Equals(offer.Place) && o.Time.TimeOfDay == offer.Time.TimeOfDay
                    && o.Time.Date == offer.Time.Date && o.AssociateName.Equals(offer.AssociateName))
                    return true;
            }
            return false;
        }

    }
}
