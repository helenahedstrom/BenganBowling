using System.Collections.Generic;
using BenganBowling.User.Classes;
using Newtonsoft.Json;

namespace BenganBowling.Cup.Classes
{
    public class CupPlayerModel
    {
        public CupPlayerModel()
        {
            Opponents = new List<Member>();
        }
        public int Id { get; set; }
        [JsonProperty("cupPlayer")]
        public Member Player { get; set; }
        public List<Member> Opponents { get; set; }
        public int PlayedGames { get; set; }
        public int WonGames { get; set; }
        public float CupTotalScore { get; set; }

    }
}
