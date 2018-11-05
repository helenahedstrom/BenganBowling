using BenganBowling.User.Classes;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.User
{
    public class MemberManager
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<Member> GetMembers(List<Member> members)
        {

            foreach (var member in members)
            {
                Log.Info(member.Name + " är medlem.");

            }
            return members;
        }

        public bool AddMember(string name, string address, string zipCode, string city, string email)
        {

            var member = new Member()
            {
                Name = name,
                Address = address,
                ZipCode = zipCode,
                City = city,
                Email = email         
            };
            if(member != null)
            {
                Log.Info(member.Name + " är tillagd som medlem.");
                return true;
            }
            else
            {
                return false;
            }

            
            
        }

        public bool AddMembershipsToMembers(List<Member> members)
        {
            var year = DateTime.Now.Year.ToString();
            foreach (var member in members)
            {
                var ms = new Membership();
                ms.Member = member;
                ms.Year = year;
                ms.HasPaidMembership = true;
                Observer observer = new Observer(member.Name);
                ms.Subscribe(observer);

                if (ms.HasPaidMembership == true)
                {
                    Log.InfoFormat("{0} har ett medlemsskap som gäller år {1}", member.Name, ms.Year);

                }
                else
                {
                    Log.InfoFormat("{0} har inte betalat medlemsskap för år {1}", member.Name, ms.Year);
                }

            }
            if (true)
            {
                return true;
            }
        }

        public bool ChangeMembershipsStatus(Membership ms)
        {
            var year = DateTime.Now.Year.ToString();

                if (ms.HasPaidMembership == true)
                {
                    Log.InfoFormat("Du har ett medlemsskap som gäller år {0}", ms.Year);
                    return true;
                }
                else
                {
                    Log.InfoFormat("Du har inte betalat medlemsskap för år {0}", ms.Year);
                    return false;
                }

            
        }
    }
}
