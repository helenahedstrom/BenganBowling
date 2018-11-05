using BenganBowling.User.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.User
{
    
    public abstract class Observable
    {
        private Member _member;
        private bool _hasPaidMembership;
        public Observable(Member member, bool hasPaidMembership)
        {
            this._member = member;
            this._hasPaidMembership = hasPaidMembership;
        }
        private List<Observer> observers = new List<Observer>();
        private string _int;

        public string Year
        {
            get
            {
                return _int;
            }
            set
            {

                if (DateTime.Now.Year.ToString() != value)
                    _int = DateTime.Now.Year.ToString();
                Notify();

            }
        }

        public void Subscribe(Observer observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            this._hasPaidMembership = false;
            observers.ForEach(x => x.Update(_hasPaidMembership, Year, _member));
        }
    }
}
