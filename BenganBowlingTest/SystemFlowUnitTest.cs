//using BenganBowling.Cup;
//using BenganBowling.Cup.Classes;
//using BenganBowling.User;
//using BenganBowling.User.Classes;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BenganBowlingTest
//{
//    [TestClass]
//    public class SystemFlowUnitTest
//    {
//        CupManager cupManager = new CupManager();
//        GameManager gameManager = new GameManager();
//        MemberManager memberManager = new MemberManager();
        

//        CupModel cup = new CupModel()
//        {
//            Name = "HöstCupen",
//            StartDate = DateTime.Parse("2018-10-11"),
//            EndDate = DateTime.Parse("2018-10-30"),
//            Id = 1
//        };



//        private List<Member> GetAllMembers()
//        {
//            using (StreamReader file = File.OpenText(@"D:\Helena\Documents\Prog17\Objektorienterad analys\Bengans\Bengan\Bengans\JsonData\Members.json"))
//            {
//                JsonSerializer serializer = new JsonSerializer();
//                return (List<Member>)serializer.Deserialize(file, typeof(List<Member>));
//            }

//        }

//        private List<CupPlayerModel> GetAllCupPlayers()
//        {
//            using (StreamReader file = File.OpenText(@"D:\Helena\Documents\Prog17\Objektorienterad analys\BenganBowling\BenganBowlingTest\TestData\CupPlayerTestData.json"))
//            {
//                JsonSerializer serializer = new JsonSerializer();
//                return (List<CupPlayerModel>)serializer.Deserialize(file, typeof(List<CupPlayerModel>));
//            }

//        }

//        private List<GameModel> GetAllGames()
//        {
//            using (StreamReader file = File.OpenText(@"D:\Helena\Documents\Prog17\Objektorienterad analys\BenganBowling\BenganBowlingTest\TestData\GameTestData.json"))
//            {
//                JsonSerializer serializer = new JsonSerializer();
//                return (List<GameModel>)serializer.Deserialize(file, typeof(List<GameModel>));
//            }

//        }




//        [TestMethod]
//        public void Test_SystemFlow()
//        {

//            Member member1 = new Member { Id = "1", Name = "Helena Hedström", Address = "Småbrukets Backe 32", ZipCode = "12345", City = "Huddinge", Email = "hej@mail.com" };
//            Member member2 = new Member { Id = "2", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member3 = new Member { Id = "3", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member4 = new Member { Id = "4", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member5 = new Member { Id = "5", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member6 = new Member { Id = "6", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member7 = new Member { Id = "7", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member8 = new Member { Id = "8", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member9 = new Member { Id = "9", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member10 = new Member { Id = "10", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member11 = new Member { Id = "11", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member12 = new Member { Id = "12", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            Member member13 = new Member { Id = "13", Name = "Mimmi Mimmisson", Address = "Småbrukets Backe 38", ZipCode = "12345", City = "Huddinge", Email = "Mimmi@mail.com" };
//            CupPlayerModel player1 = new CupPlayerModel { Player = member1 };
//            CupPlayerModel player2 = new CupPlayerModel { Player = member2 };
//            CupPlayerModel player3 = new CupPlayerModel { Player = member3};

//            GameModel game1 = new GameModel(player1, player2);
//            GameModel game2 = new GameModel(player1, player3);

//            List<Member> allMembers = GetAllMembers();
//            List<GameModel> games = GetAllGames();

//            memberManager.AddMembers(allMembers);
//            memberManager.AddMembershipsToMembers(allMembers);
//            cupManager.CreateCup(cup);
//            var cupPlayers = cupManager.AddMembersToCup(cup, allMembers);
//            var playerOneResults = new List<int>() { 100, 180, 250 };
//            var playerTwoResults = new List<int>() { 100, 100, 250 };
//            foreach (var game in games)
//            {
//                gameManager.GamePlay(game, playerOneResults, playerTwoResults);
//            }






//            //Assert.AreEqual(true, actual);

//        }

//    }
//}
