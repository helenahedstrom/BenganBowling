using BenganBowling.Cup.Classes;
using BenganBowling.User.Classes;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.Cup
{
    /// <summary>

    /// The 'Context' class

    /// </summary>
    public class GameManager
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GameStrategy _gameStrategy;

        public void SetGameStrategy(GameStrategy gamestrategy)
        {
            this._gameStrategy = gamestrategy;
        }

        public void RegisterGameInCup (CupModel cup, CupPlayerModel playerOne, CupPlayerModel playerTwo)
        {
            if (cup.StartDate > DateTime.Now)
            {
                //RegisterGameHelper(cupPlayerOne, cupPlayerTwo);
            }
        }

        public bool ChallengeOpponent(CupPlayerModel playerOne, CupPlayerModel playerTwo)
        {
            var playerOneListOfOpponents = playerOne.Opponents;

            var playerTwoListOfOpponents = playerTwo.Opponents;

            var opponentPlayerOne = playerOneListOfOpponents.Where(a => a.Id == playerTwo.Player.Id).FirstOrDefault();

            var opponentPlayerTwo = playerTwoListOfOpponents.Where(a => a.Id == playerOne.Player.Id).FirstOrDefault();

            if (opponentPlayerOne == null && opponentPlayerTwo == null)
            {
                playerOne.Opponents.Add(playerTwo.Player);
                playerTwo.Opponents.Add(playerOne.Player);

                Log.InfoFormat("{0} utmanar {1}", playerOne.Player.Name, playerTwo.Player.Name);

                return true;
            }
            else
            {
                Log.Info("Ni har redan spelat mot varandra");
                return false;
            }
        }

        public GameModel GamePlay(GameModel game, List<int> player1Results, List<int> player2Results )
        {
            game.PlayerOnePoints = _gameStrategy.PlayGame(player1Results);
            game.PlayerTwoPoints = _gameStrategy.PlayGame(player2Results);
            game.PlayerOne.PlayedGames += 1;
            game.PlayerTwo.PlayedGames += 1;


            if (game.PlayerOnePoints > game.PlayerTwoPoints)
            {
                game.Winner = game.PlayerOne;
                game.PlayerOne.WonGames += 1;
                Log.InfoFormat("{0} vann!", game.PlayerOne.Player.Name);
            }
            else
            {
                game.Winner = game.PlayerTwo;
                game.PlayerTwo.WonGames += 1;
                Log.InfoFormat("{0} vann!", game.PlayerTwo.Player.Name);
            }
            return game;

        }

     

    }
}
