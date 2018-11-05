using BenganBowling.Champion.Classes;
using BenganBowling.Cup;
using BenganBowling.Cup.Classes;
using BenganBowling.User;
using BenganBowling.User.Classes;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling
{
    public class BasicMaths
    {
        public List<Member> GetAllMembers()
        {
            using (StreamReader file = File.OpenText(@"D:\Helena\Documents\Prog17\Objektorienterad analys\Bengans\Bengan\Bengans\JsonData\Members.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<Member>)serializer.Deserialize(file, typeof(List<Member>));
            }

        }

        public List<CupPlayerModel> GetAllCupPlayers()
        {
            using (StreamReader file = File.OpenText(@"D:\Helena\Documents\Prog17\Objektorienterad analys\BenganBowling\BenganBowlingTest\TestData\CupPlayerTestData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<CupPlayerModel>)serializer.Deserialize(file, typeof(List<CupPlayerModel>));
            }

        }

        public List<GameModel> GetGames()
        {
            using (StreamReader file = File.OpenText(@"D:\Helena\Documents\Prog17\Objektorienterad analys\BenganBowling\BenganBowlingTest\TestData\GameTestData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<GameModel>)serializer.Deserialize(file, typeof(List<GameModel>));
            }

        }

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public double Add(double num1, double num2)
        {
            var loginfo = "Add " + num1 + "+" + num2 + "= stuff";
            Log.Info(loginfo);

            return num1 + num2;
        }
        public double Substract(double num1, double num2)
        {
            var loginfo = "Substract " + num1 + "-" + num2 + "= stuff";
            Log.Info(loginfo);
            return num1 - num2;
        }
        public double divide(double num1, double num2)
        {
            var loginfo = "Divide " + num1 + "//" + num2 + "= stuff";
            Log.Info(loginfo);
            return num1 / num2;
        }
        public double Multiply(double num1, double num2)
        {
            // To trace error while testing, writing + operator instead of * operator.  
            return num1 + num2;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //var math = new BasicMaths();
            //math.Add(15, 18);

            //var cup = new CupManager();
            var cup = new CupModel()
            {
                Name = "JulCupen",
                StartDate = DateTime.Parse("2018-12-01"),
                EndDate = DateTime.Parse("2018-12-31"),
                Id = 1
            };

            //using (StreamReader file = File.OpenText(@"D:\Helena\Documents\Prog17\Objektorienterad analys\Bengans\Bengan\Bengans\JsonData\Members.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    var list = (List<Member>)serializer.Deserialize(file, typeof(List<Member>));
            //    cup.AddMembersToCup(cup1, list);
            //}

            var game = new GameManager();


            //game.SetGameStrategy(new ThreeSetStrategy());
            //game.RegisterGame();
            //Member member2 = new Member();
            //member2.Name = "Helena";

            //Membership ms2 = new Membership();
            //Observer observer2 = new Observer();
            //ms2.Subscribe(observer2);

            //ms2.Member = member2;
            //ms2.HasPaidMembership = true;
            //ms2.Year = "2018";
            //Console.WriteLine(ms2.Year);

            Member member = new Member();
            member.Name = "Helena";

            //Member member2 = new Member();
            //member2.Name = "Mimmi";

            Membership ms = new Membership();
            member.Membership = ms;
            ms.Year = "2018";
            Observer observer = new Observer(member.Name);
            ms.Subscribe(observer);

            ms.Year = "2016";
            //Console.WriteLine(ms.Year);

            //var mm = new MemberManager();
            var bm = new BasicMaths();
            //mm.AddMembers(bm.GetAllMembers());
            var cm = new CupManager();
            //cm.AddMembersToCup(cup1, bm.GetAllMembers());

            //Observer observer = new Observer();
            //ms.HasPaidMembership = true;
            //ms.Subscribe(observer);

            //var cupPlayer = new CupPlayerModel()
            //{
            //    Player = member,
            //    PlayedGames = 10,
            //    WonGames = 5
            //};

            //var cupPlayer2 = new CupPlayerModel()
            //{
            //    Player = member2,
            //    PlayedGames = 12,
            //    WonGames = 5
            //};

            //cup1.Players.Add(cupPlayer);
            //cup1.Players.Add(cupPlayer2);

            //var game2 = new GameModel(cupPlayer, cupPlayer2)
            //{
            //    DateofGame = DateTime.Now,
            //    Winner = cupPlayer2
            //};

            //var game3 = new GameModel(cupPlayer2, cupPlayer)
            //{
            //    DateofGame = DateTime.Now,
            //    Winner = cupPlayer
            //};


            //var listOfGames = new List<GameModel>();
            //listOfGames.Add(game2);
            //listOfGames.Add(game3);

            //cup1.Games.Add(game2);
            //cup1.Games.Add(game3);

            //cm.ChampionWinner(listOfGames);

            //cm.CupWinner(cup1);

            //var hej = bm.GetAllCupPlayers();

            //var test = bm.GetGames();
            //var playerOneResults = new List<int>() { 100, 180, 250 };
            //var playerTwoResults = new List<int>() { 100, 100, 250 };
            //game.SetGameStrategy(new ThreeSetStrategy());

            //Member member1 = new Member { Id = "1", Name = "Helena Hedström", Address = "Småbrukets Backe 32", ZipCode = "12345", City = "Huddinge", Email = "hej@mail.com" };
            //Member member2 = new Member { Id = "2", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member3 = new Member { Id = "3", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member4 = new Member { Id = "4", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member5 = new Member { Id = "5", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member6 = new Member { Id = "6", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member7 = new Member { Id = "7", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member8 = new Member { Id = "8", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member9 = new Member { Id = "9", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member10 = new Member { Id = "10", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member11 = new Member { Id = "11", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member12 = new Member { Id = "12", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member13 = new Member { Id = "13", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };

            //CupPlayerModel player1 = new CupPlayerModel { Player = member1, Id= 1};
            //CupPlayerModel player2 = new CupPlayerModel { Player = member2, Id = 2 };
            //CupPlayerModel player3 = new CupPlayerModel { Player = member3, Id = 3 };
            //CupPlayerModel player4 = new CupPlayerModel { Player = member4, Id = 4 };
            //CupPlayerModel player5 = new CupPlayerModel { Player = member5, Id = 5 };
            //CupPlayerModel player6 = new CupPlayerModel { Player = member6, Id = 6 };
            //CupPlayerModel player7 = new CupPlayerModel { Player = member1, Id = 7 };
            //CupPlayerModel player8 = new CupPlayerModel { Player = member8, Id = 8 };
            //CupPlayerModel player9 = new CupPlayerModel { Player = member9, Id = 9};
            //CupPlayerModel player10 = new CupPlayerModel { Player = member10, Id = 10 };
            //CupPlayerModel player11 = new CupPlayerModel { Player = member11 };
            //CupPlayerModel player12 = new CupPlayerModel { Player = member12 };


            //GameModel game1 = new GameModel(player1, player2);
            //GameModel game2 = new GameModel(player1, player3);
            //GameModel game3 = new GameModel(player4, player1);
            //GameModel game4 = new GameModel(player1, player5);
            //GameModel game5 = new GameModel(player1, player6);
            //GameModel game6 = new GameModel(player1, player7);
            //GameModel game7 = new GameModel(player1, player8);
            //GameModel game8 = new GameModel(player1, player9);
            //GameModel game9 = new GameModel(player1, player10);
            //GameModel game10 = new GameModel(player1, player11);
            //GameModel game11 = new GameModel(player12, player3);
            //GameModel game12 = new GameModel(player2, player3);
            //GameModel game13 = new GameModel(player4, player3);
            //GameModel game14 = new GameModel(player5, player3);
            //GameModel game15 = new GameModel(player6, player3);
            //GameModel game16 = new GameModel(player7, player3);
            //GameModel game17 = new GameModel(player8, player3);
            //GameModel game18 = new GameModel(player9, player3);
            //GameModel game19 = new GameModel(player10, player3);
            //GameModel game20 = new GameModel(player11, player3);

            //game1.DateofGame = DateTime.Parse("2018-09-12");
            //game2.DateofGame = DateTime.Parse("2018-09-13");
            //game3.DateofGame = DateTime.Parse("2018-09-15");

            //game.ChallengeOpponent(player1, player2);
            //game.ChallengeOpponent(player1, player2);
            //game.ChallengeOpponent(player3, player7);

            //game.RegisterGame(game1, new List<int>() { 100, 180, 250 }, new List<int>() { 100, 100, 250 });
            //game.RegisterGame(game2, new List<int>() { 100, 200, 200 }, new List<int>() { 100, 300, 250 });
            //game.RegisterGame(game3, new List<int>() { 100, 200, 200 }, new List<int>() { 100, 300, 250 });

            //var champion = new ChampionOfTheYear();
            //champion.AllGames.Add(game1);
            //champion.AllGames.Add(game2);
            //champion.AllGames.Add(game3);
            //champion.Year = 2018;
            //Member member1 = new Member { Id = "1", Name = "Helena Hedström", Address = "Småbrukets Backe 32", ZipCode = "12345", City = "Huddinge", Email = "hej@mail.com" };
            //Member member2 = new Member { Id = "2", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member3 = new Member { Id = "3", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member4 = new Member { Id = "4", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member5 = new Member { Id = "5", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member6 = new Member { Id = "6", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member7 = new Member { Id = "7", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member8 = new Member { Id = "8", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member9 = new Member { Id = "9", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member10 = new Member { Id = "10", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };

            //CupPlayerModel player1 = new CupPlayerModel { Player = member1, Id = 1, WonGames = 7, PlayedGames = 10 };
            //CupPlayerModel player2 = new CupPlayerModel { Player = member2, Id = 2, WonGames = 1, PlayedGames = 2 };
            //CupPlayerModel player3 = new CupPlayerModel { Player = member3, Id = 3, WonGames = 1, PlayedGames = 1 };
            //CupPlayerModel player4 = new CupPlayerModel { Player = member4, Id = 4, WonGames = 0, PlayedGames = 1 };
            //CupPlayerModel player5 = new CupPlayerModel { Player = member5, Id = 5, WonGames = 1, PlayedGames = 1 };
            //CupPlayerModel player6 = new CupPlayerModel { Player = member6, Id = 6, WonGames = 0, PlayedGames = 1 };
            //CupPlayerModel player7 = new CupPlayerModel { Player = member1, Id = 7, WonGames = 0, PlayedGames = 1 };
            //CupPlayerModel player8 = new CupPlayerModel { Player = member8, Id = 8, WonGames = 1, PlayedGames = 1 };
            //CupPlayerModel player9 = new CupPlayerModel { Player = member9, Id = 9, WonGames = 0, PlayedGames = 1 };
            //CupPlayerModel player10 = new CupPlayerModel { Player = member10, Id = 10, WonGames = 0, PlayedGames = 1 };

            //GameModel game1 = new GameModel(player1, player2) { DateofGame = DateTime.Parse("2018-09-12"), Winner = player1};
            //GameModel game2 = new GameModel(player1, player3) { DateofGame = DateTime.Parse("2018-09-15"), Winner = player3 };
            //GameModel game3 = new GameModel(player4, player1) { DateofGame = DateTime.Parse("2018-10-12"), Winner = player1 };
            //GameModel game4 = new GameModel(player1, player5) { DateofGame = DateTime.Parse("2018-11-12"), Winner = player5 };
            //GameModel game5 = new GameModel(player1, player6) { DateofGame = DateTime.Parse("2018-12-12"), Winner = player1 };
            // GameModel game6 = new GameModel(player2, player7) { DateofGame = DateTime.Parse("2018-11-18"), Winner = player2 };
            //GameModel game7 = new GameModel(player1, player8) { DateofGame = DateTime.Parse("2018-12-22"), Winner = player8 };
            //GameModel game8 = new GameModel(player1, player9) { DateofGame = DateTime.Parse("2017-09-12"), Winner = player1 };
            // GameModel game9 = new GameModel(player1, player10) { DateofGame = DateTime.Parse("2018-09-01"), Winner = player1 };
            //GameModel game10= new GameModel(player1, player9) { DateofGame = DateTime.Parse("2018-05-12"), Winner = player1 };
            // GameModel game11 = new GameModel(player1, player10) { DateofGame = DateTime.Parse("2018-03-01"), Winner = player1 };

            //var champOfYear = new ChampionOfTheYear();

            //champOfYear.AllGames.Add(new GameModel(player1, player2) { DateofGame = DateTime.Parse("2018-09-12"), Winner = player1 });
            //champOfYear.AllGames.Add(new GameModel(player1, player3) { DateofGame = DateTime.Parse("2018-09-15"), Winner = player3 });
            //champOfYear.AllGames.Add(new GameModel(player4, player1) { DateofGame = DateTime.Parse("2018-10-12"), Winner = player1 });
            //champOfYear.AllGames.Add(new GameModel(player1, player5) { DateofGame = DateTime.Parse("2018-11-12"), Winner = player5 });
            //champOfYear.AllGames.Add(new GameModel(player1, player6) { DateofGame = DateTime.Parse("2018-12-12"), Winner = player1 });
            //champOfYear.AllGames.Add(new GameModel(player2, player7) { DateofGame = DateTime.Parse("2018-11-18"), Winner = player2 });
            //champOfYear.AllGames.Add(new GameModel(player1, player8) { DateofGame = DateTime.Parse("2018-12-22"), Winner = player8 });
            //champOfYear.AllGames.Add(new GameModel(player1, player9) { DateofGame = DateTime.Parse("2017-09-12"), Winner = player1 });
            //champOfYear.AllGames.Add(new GameModel(player1, player10) { DateofGame = DateTime.Parse("2018-09-01"), Winner = player1 });
            //champOfYear.AllGames.Add(new GameModel(player1, player9) { DateofGame = DateTime.Parse("2018-05-12"), Winner = player1 });
            //champOfYear.AllGames.Add(new GameModel(player1, player10) { DateofGame = DateTime.Parse("2018-03-01"), Winner = player1 });

            //champOfYear.Year = 2018;

            //var cupManager = new CupManager();

            ////var actual = cupManager.ChampionWinner(champOfYear);

            //Member member1 = new Member { Id = "1", Name = "Helena Hedström", Address = "Småbrukets Backe 32", ZipCode = "12345", City = "Huddinge", Email = "hej@mail.com" };
            //Member member2 = new Member { Id = "2", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            //Member member3 = new Member { Id = "3", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };

            //CupPlayerModel player1 = new CupPlayerModel { Player = member1, Id = 1, Opponents = { member3 } };
            //CupPlayerModel player2 = new CupPlayerModel { Player = member2, Id = 2 };
            //CupPlayerModel player3 = new CupPlayerModel { Player = member3, Id = 3 };

            //var gameManager = new GameManager();

            //var actual = gameManager.ChallengeOpponent(player1, player2);

            //var gameManager = new GameManager();
            //gameManager.SetGameStrategy(new ThreeSetStrategy());
            //var games = new GameModel(new CupPlayerModel(), new CupPlayerModel());

            //var playerOneResults = new List<int>() { 100, 180, 250 };
            //var playerTwoResults = new List<int>() { 100, 100, 250 };


            //gameManager.GamePlay(games, playerOneResults, playerTwoResults);

            var cupPlayer = new CupPlayerModel()
            {
                Player = new Member() { Name = "Martin Frost" },
                PlayedGames = 10,
                WonGames = 5
            };

            var cupPlayer2 = new CupPlayerModel()
            {
                Player = new Member() { Name = "Dianne Cherry" },
                PlayedGames = 12,
                WonGames = 5
            };

            var cups = new CupModel()
            {
                Name = "JulCupen",
                StartDate = DateTime.Parse("2018-12-01"),
                EndDate = DateTime.Parse("2018-12-31"),
                Id = 1,
                Players = { cupPlayer, cupPlayer2 }

            };

            var cupManager = new CupManager();

            var actual = cupManager.CupWinner(cups);

        }

    }
}
