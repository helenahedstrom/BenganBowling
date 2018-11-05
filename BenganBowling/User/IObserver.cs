using BenganBowling.User.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.User
{
    /// <summary>

    /// The 'Observer' interface

    /// </summary>
    interface IObserver
    {
        string Update(bool HasPaidMembership, string Year, Member Member);
    }
}
