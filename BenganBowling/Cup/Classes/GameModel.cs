using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.Cup.Classes
{
    public class GameModel
    {
        public GameModel(CupPlayerModel playerOne, CupPlayerModel playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public int Id { get; set; }

        [JsonProperty("playerOne")]
        public CupPlayerModel PlayerOne { get; set; }

        [JsonProperty("playerTwo")]
        public CupPlayerModel PlayerTwo { get; set; }

        public int PlayerOnePoints { get; set; }

        public int PlayerTwoPoints { get; set; }

        public DateTime DateofGame { get; set; }

        public CupPlayerModel Winner { get; set; }


    }
}
