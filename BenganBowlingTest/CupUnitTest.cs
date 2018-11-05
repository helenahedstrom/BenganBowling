using BenganBowling;
using BenganBowling.Champion;
using BenganBowling.Champion.Classes;
using BenganBowling.Cup;
using BenganBowling.Cup.Classes;
using BenganBowling.User;
using BenganBowling.User.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowlingTest
{
    [TestClass]
    public class CupUnitTest
    {
        public MemberManager memberManager = new MemberManager();

        [TestMethod]
        public void Test_GetMembers()
        {
            var actual = memberManager.GetMembers(GetAllMembers());

            Assert.AreEqual(GetAllMembers().Count, actual.Count);
        }

        [TestMethod]
        public void Test_AddMember()
        {
            var actual = memberManager.AddMember("Helena", "Småbrukets Backe 32", "14158", "Huddinge", "Helena@gmail.com");

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Test_AddMembershipToMember()
        {
            var actual = memberManager.AddMembershipsToMembers(GetAllMembers());

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Test_ChangeMembershipsStatus()
        {
            var ms = new Membership() { HasPaidMembership = true, Year = "2017", Member = new Member() {Name = "Helena"} };
            Observer observer = new Observer(ms.Member.Name);
            ms.Subscribe(observer);

            var actual = memberManager.ChangeMembershipsStatus(ms);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Test_CreateCup()
        {
            var cup = new CupModel()
            {
                Name = "JulCupen",
                StartDate = DateTime.Parse("2018-12-01"),
                EndDate = DateTime.Parse("2018-12-31"),
                Id = 1
            };

            var cupManager = new CupManager();

            var actual = cupManager.CreateCup(cup);

            Assert.AreEqual(true, actual);

        }

        [TestMethod]
        public void Test_AddMembersToCup()
        {
            var cup = new CupModel()
            {
                Name = "JulCupen",
                StartDate = DateTime.Parse("2018-12-01"),
                EndDate = DateTime.Parse("2018-12-31"),
                Id = 1
            };

            var cupManager = new CupManager();

            var members = GetAllMembers();

            var actual = cupManager.AddMembersToCup(cup, members);

            Assert.AreEqual(members.Count, actual.Count);

        }

        [TestMethod]
        public void Test_ChallengeMembers()
        {
            Member member1 = new Member { Id = "1", Name = "Helena Hedström", Address = "Småbrukets Backe 32", ZipCode = "12345", City = "Huddinge", Email = "hej@mail.com" };
            Member member2 = new Member { Id = "2", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            Member member3 = new Member { Id = "3", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            
            CupPlayerModel player1 = new CupPlayerModel { Player = member1, Id = 1 };
            CupPlayerModel player2 = new CupPlayerModel { Player = member2, Id = 2, Opponents = { member3}};
            CupPlayerModel player3 = new CupPlayerModel { Player = member3, Id = 3 };
           
            var gameManager = new GameManager();

            var actual = gameManager.ChallengeOpponent(player1, player2);

            Assert.AreEqual(true, actual);

        }

        [TestMethod]
        public void Test_RegisterGame()
        {
            var gameManager = new GameManager();
            gameManager.SetGameStrategy(new ThreeSetStrategy());
            var member1 = new Member() { Name = "Helena" };
            var member2 = new Member() { Name = "Mimmi" };
            var game = new GameModel(new CupPlayerModel() { Player = member1}, new CupPlayerModel() { Player = member2 });

            var playerOneResults = new List<int>() { 100, 180, 250};
            var playerTwoResults = new List<int>() { 100, 100, 250};


            gameManager.GamePlay(game, playerOneResults, playerTwoResults);

            Assert.AreEqual(game.PlayerOne, game.Winner);

        }

        [TestMethod]
        public void Test_GetCupWinner()
        {

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

            var cup = new CupModel()
            {
                Name = "HöstCupen",
                StartDate = DateTime.Parse("2018-10-01"),
                EndDate = DateTime.Parse("2018-12-31"),
                Id = 1,
                Players = { cupPlayer, cupPlayer2}
                
            };

            var cupManager = new CupManager();

            var actual = cupManager.CupWinner(cup);

            Assert.AreEqual(cupPlayer, actual);

        }

        [TestMethod]
        public void Test_GetYearWinner()
        {

            Member member1 = new Member { Id = "1", Name = "Martin Frost", Address = "Småbrukets Backe 32", ZipCode = "12345", City = "Huddinge", Email = "hej@mail.com" };
            Member member2 = new Member { Id = "2", Name = "Helena Hedström", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            Member member3 = new Member { Id = "3", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            Member member4 = new Member { Id = "4", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            Member member5 = new Member { Id = "5", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            Member member6 = new Member { Id = "6", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            Member member7 = new Member { Id = "7", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            Member member8 = new Member { Id = "8", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            Member member9 = new Member { Id = "9", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
            Member member10 = new Member { Id = "10", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };

            CupPlayerModel player1 = new CupPlayerModel { Player = member1, Id = 1, WonGames = 7, PlayedGames =10};
            CupPlayerModel player2 = new CupPlayerModel { Player = member2, Id = 2, WonGames = 1, PlayedGames = 2 };
            CupPlayerModel player3 = new CupPlayerModel { Player = member3, Id = 3, WonGames = 1, PlayedGames = 1};
            CupPlayerModel player4 = new CupPlayerModel { Player = member4, Id = 4, WonGames = 0, PlayedGames = 1};
            CupPlayerModel player5 = new CupPlayerModel { Player = member5, Id = 5, WonGames = 1, PlayedGames = 1 };
            CupPlayerModel player6 = new CupPlayerModel { Player = member6, Id = 6, WonGames = 0, PlayedGames = 1 };
            CupPlayerModel player7 = new CupPlayerModel { Player = member1, Id = 7, WonGames = 0, PlayedGames = 1 };
            CupPlayerModel player8 = new CupPlayerModel { Player = member8, Id = 8, WonGames = 1, PlayedGames = 1 };
            CupPlayerModel player9 = new CupPlayerModel { Player = member9, Id = 9, WonGames = 0, PlayedGames = 1 };
            CupPlayerModel player10 = new CupPlayerModel { Player = member10, Id = 10, WonGames = 0, PlayedGames = 1 };

            var champOfYear = new ChampionOfTheYear();

            champOfYear.AllGames.Add(new GameModel(player1, player2) { DateofGame = DateTime.Parse("2018-09-12"), Winner = player1 });
            champOfYear.AllGames.Add(new GameModel(player1, player3) { DateofGame = DateTime.Parse("2018-09-15"), Winner = player3 });
            champOfYear.AllGames.Add(new GameModel(player4, player1) { DateofGame = DateTime.Parse("2018-10-12"), Winner = player1 });
            champOfYear.AllGames.Add(new GameModel(player1, player5) { DateofGame = DateTime.Parse("2018-11-12"), Winner = player5 });
            champOfYear.AllGames.Add(new GameModel(player1, player6) { DateofGame = DateTime.Parse("2018-12-12"), Winner = player1 });
            champOfYear.AllGames.Add(new GameModel(player2, player7) { DateofGame = DateTime.Parse("2018-11-18"), Winner = player2 });
            champOfYear.AllGames.Add(new GameModel(player1, player8) { DateofGame = DateTime.Parse("2018-12-22"), Winner = player8 });
            champOfYear.AllGames.Add(new GameModel(player1, player9) { DateofGame = DateTime.Parse("2017-09-12"), Winner = player1 });
            champOfYear.AllGames.Add(new GameModel(player1, player10) { DateofGame = DateTime.Parse("2018-09-01"), Winner = player1 });
            champOfYear.AllGames.Add(new GameModel(player1, player9) { DateofGame = DateTime.Parse("2018-05-12"), Winner = player1 });
            champOfYear.AllGames.Add(new GameModel(player1, player10) { DateofGame = DateTime.Parse("2018-03-01"), Winner = player1 });

            champOfYear.Year = 2018;

            var champManager = new ChampionOfTheYearManager();

            var actual = champManager.ChampionWinner(champOfYear);

            Assert.AreEqual("1", actual);

        }



        private List<Member> GetAllMembers()
        {
            using (StreamReader file = File.OpenText(@"D:\Helena\Documents\Prog17\Objektorienterad analys\Bengans\Bengan\Bengans\JsonData\Members.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<Member>)serializer.Deserialize(file, typeof(List<Member>));
            }

        }
    }


}
