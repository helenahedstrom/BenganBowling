using BenganBowling.Champion.Classes;
using BenganBowling.Cup.Classes;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.Champion
{
    public class ChampionOfTheYearManager
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string ChampionWinner(ChampionOfTheYear champion)
        {
            var games = champion.AllGames.Where(a => a.DateofGame.Year == champion.Year).ToList();

            var gamePlayers = new List<CupPlayerModel>();

            Dictionary<string, int[]> dictionaryOfPlayers = new Dictionary<string, int[]>();

            foreach (var item in games)
            {
                if (dictionaryOfPlayers.ContainsKey(item.PlayerOne.Player.Id))
                {
                    dictionaryOfPlayers[item.PlayerOne.Player.Id][0] = item.PlayerOne.WonGames;
                    dictionaryOfPlayers[item.PlayerOne.Player.Id][1] = item.PlayerOne.PlayedGames;
                }
                else
                {
                    dictionaryOfPlayers.Add(item.PlayerOne.Player.Id, new int[] { item.PlayerOne.WonGames, item.PlayerOne.PlayedGames });
                }
                if (dictionaryOfPlayers.ContainsKey(item.PlayerTwo.Player.Id))
                {
                    dictionaryOfPlayers[item.PlayerTwo.Player.Id][0] = item.PlayerTwo.WonGames;
                    dictionaryOfPlayers[item.PlayerTwo.Player.Id][1] = item.PlayerTwo.PlayedGames;
                }
                else
                {
                    dictionaryOfPlayers.Add(item.PlayerTwo.Player.Id, new int[] { item.PlayerTwo.WonGames, item.PlayerTwo.PlayedGames });
                }

            }

            float highestWin = 0;
            string winningMemberId = "";
            foreach (var player in dictionaryOfPlayers)
            {
                if (player.Value[1] >= 10)
                {
                    var wonGames = player.Value[0];
                    var playedGames = player.Value[1];
                    float sum = (float)wonGames / playedGames;

                    if (sum > highestWin)
                    {
                        winningMemberId = player.Key;
                        highestWin = sum;
                    }
                }
            }

            var test = champion.AllGames.Where(a => a.Winner.Player.Id == winningMemberId).Select(b => b.Winner.Player.Name).FirstOrDefault();

            Log.InfoFormat("Vinnaren för året {0} är {1} med {2} % vunna matcher", champion.Year, test, highestWin * 100);
            return winningMemberId;


        }
    }
}
