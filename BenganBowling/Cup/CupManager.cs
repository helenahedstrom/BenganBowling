using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenganBowling.Champion.Classes;
using BenganBowling.Cup.Classes;
using BenganBowling.User.Classes;
using log4net;

namespace BenganBowling.Cup
{
    public class CupManager
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool CreateCup(CupModel cup)
        {
            Log.Info(cup.Name + " försöker sparas");

            if (true)
            {
                Log.Info(cup.Name + " sparades");
                return true;
            }

            else
            {
                Log.Info(cup.Name + "Kunde inte sparas");
                return false;
            }
        }

        public List<CupPlayerModel> AddMembersToCup(CupModel cup, List<Member> members)
        {
            
            if(members.Count > 10)
            {
                foreach (var member in members)
                {
                    var cupApplication = new CupApplicationModel();
                    cupApplication.CupId = cup.Id;
                    cupApplication.MemberId = member.Id;
                    cupApplication.HasPaidCup = true;
                    var cupPlayer = new CupPlayerModel();
                    cupPlayer.Player = member;
                    cupPlayer.Opponents.Add(member);
                    cup.Players.Add(cupPlayer);              

                    Log.Info(member.Name + " är med i cuppen " + cup.Name);
                }
            }
            else
            {
                Log.Info("Tillräckligt med medlemmar är inte med i cuppen.");
            }

            return cup.Players;

        }

        public CupPlayerModel CupWinner(CupModel cup)
        {
            foreach (var player in cup.Players)
            {
                if (player.PlayedGames >= 10)
                {
                    Log.InfoFormat("Spelare {0} har spelat {1} matcher och vunnit {2} matcher", player.Player.Name, player.PlayedGames, player.WonGames);
                    player.CupTotalScore = (float)player.WonGames / player.PlayedGames;
                }
            }

            var winner = cup.Players.OrderByDescending(i => i.CupTotalScore).FirstOrDefault();
            Log.InfoFormat("Vinnaren i cuppen {0} är {1}", cup.Name, winner.Player.Name);
            return winner;

        }

        //public string ChampionWinner(ChampionOfTheYear champion)
        //{
        //    var games = champion.AllGames.Where(a => a.DateofGame.Year == champion.Year).ToList();

        //    var gamePlayers = new List<CupPlayerModel>();

        //    Dictionary<string, int[]> dictionaryOfPlayers = new Dictionary<string, int[]>();

        //    foreach (var item in games)
        //    {
        //        if (dictionaryOfPlayers.ContainsKey(item.PlayerOne.Player.Id)) {
        //            dictionaryOfPlayers[item.PlayerOne.Player.Id][0] = item.PlayerOne.WonGames;
        //            dictionaryOfPlayers[item.PlayerOne.Player.Id][1] = item.PlayerOne.PlayedGames;
        //        }
        //        else
        //        {
        //            dictionaryOfPlayers.Add(item.PlayerOne.Player.Id, new int[] { item.PlayerOne.WonGames, item.PlayerOne.PlayedGames });
        //        }
        //        if (dictionaryOfPlayers.ContainsKey(item.PlayerTwo.Player.Id))
        //        {
        //            dictionaryOfPlayers[item.PlayerTwo.Player.Id][0] = item.PlayerTwo.WonGames;
        //            dictionaryOfPlayers[item.PlayerTwo.Player.Id][1] = item.PlayerTwo.PlayedGames;
        //        }
        //        else
        //        {                  
        //            dictionaryOfPlayers.Add(item.PlayerTwo.Player.Id, new int[] { item.PlayerTwo.WonGames, item.PlayerTwo.PlayedGames });
        //        }

        //    }

        //    float highestWin = 0;
        //    string winningMemberId = "";
        //    foreach (var player in dictionaryOfPlayers)
        //    {
        //        if (player.Value[1] >= 10)
        //        {
        //            var wonGames = player.Value[0];
        //            var playedGames = player.Value[1];
        //            float sum = (float)wonGames / playedGames;

        //            if (sum > highestWin)
        //            {
        //                winningMemberId = player.Key;
        //                highestWin = sum;
        //            }
        //        }
        //    }

        //    var test = champion.AllGames.Where(a => a.Winner.Player.Id == winningMemberId).Select(b => b.Winner.Player.Name).FirstOrDefault();

        //    Log.InfoFormat("Vinnaren för året {0} är {1}", champion.Year, test);
        //    return winningMemberId;


        //}

        
    }
}
 