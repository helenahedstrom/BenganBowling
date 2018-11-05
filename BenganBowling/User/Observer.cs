using BenganBowling.User.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.User
{
    /// <summary>

    /// The 'ConcreteObserver' class

    /// </summary>
    public class Observer : IObserver
    {
        public string ObserverName { get; private set; }
        public Observer(string name)
        {
            this.ObserverName = name;
        }
        public string Update(bool HasPaidMembership, string Year, Member Member)
        {
            Console.WriteLine("Medlemskapet för medlem {0} har blivit uppdaterat med aktuellt år {1}. {2}", ObserverName, Year, HasPaidMembership);  
             return string.Format("Medlemskapet för medlem {0} har blivit uppdaterat med aktuellt år {1}. {2}", ObserverName, Year, HasPaidMembership);
          
        }
    }
}
