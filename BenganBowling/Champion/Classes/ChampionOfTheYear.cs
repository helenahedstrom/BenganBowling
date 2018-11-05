using BenganBowling.Cup.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.Champion.Classes
{
    public class ChampionOfTheYear
    {
        public ChampionOfTheYear()
        {
            AllGames = new List<GameModel>();
        }
        public List<GameModel> AllGames { get; set; }

        public int Year { get; set; }

    }
}
