using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.User
{
    /// <summary>

    /// The 'Subject' interface class

    /// </summary>
    public interface IMembership
    {
        void Subscribe(Observer observer);
        void Unsubscribe(Observer observer);
        void Notify();
    }
}
