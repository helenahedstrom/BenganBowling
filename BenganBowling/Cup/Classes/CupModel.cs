using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.Cup.Classes
{
    public class CupModel
    {
        public CupModel()
        {
            Players = new List<CupPlayerModel>();
            Games = new List<GameModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<GameModel> Games { get; set; }

        public List<CupPlayerModel> Players { get; set; }

    }
}
