using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.User.Classes
{
    /// <summary>

    /// The 'ConcreteSubject' class

    /// </summary>
    /// </summary>
    public class Membership : IMembership
    {
        private List<Observer> observers = new List<Observer>();
        private string _year;

        public Member Member { get; set; }

        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
             
             if (DateTime.Now.Year.ToString() != value)
                {
                    _year = DateTime.Now.Year.ToString();
                    Notify();
                }
 
                else{
                    _year = value;
                }
                      


            }
        }

        public bool HasPaidMembership { get; set; }

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
            this.HasPaidMembership = false;
            observers.ForEach(x => x.Update(HasPaidMembership, Year, Member));
        }
    }
}
