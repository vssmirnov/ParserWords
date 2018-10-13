using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserComments.BL.Models;
using ParserComments.DAL.Models;

namespace ParserComments.BL.Test
{
	class WordRank: IWordRankModel
   {
	   public int TotalCount { get; set; }
	   public int CountByUniqueMessage { get; set; }
	   public string Word { get; set; }
   }
	class PhaseRank: IPhaseRankModel
   {
	   public int TotalCount { get; set; }
	   public int CountByUniqueMessage { get; set; }
	   public string Phase { get; set; }
   }

   [TestClass]
   public class ManagerRanksTest
   {
      [TestMethod]
      public void CalculateRanksTest_CheckWordRank()
      {
	      var repository = new Repositories(AppDomain.CurrentDomain.BaseDirectory);
	      repository.FileWordsStore.LoadWordsDictionary();
			repository.MessagesStore.AddMessageItem(new MessageItem(){Message = "Привет как дела"});
			repository.MessagesStore.AddMessageItem(new MessageItem(){Message = "Привет как как как как как"});
			repository.MessagesStore.AddMessageItem(new MessageItem(){Message = "как привет дила"});
			repository.MessagesStore.AddMessageItem(new MessageItem(){Message = "привет дила"});
	      var manager = new ManagerRanks(repository);
			manager.CalculateRanks();
	      var wordRanks = manager.GetWordRanks<WordRank>(t => t.CountByUniqueMessage, 5);
			Assert.AreEqual(wordRanks.Count, 3);
			Assert.AreEqual(wordRanks[0].Word, "привет");
			Assert.AreEqual(wordRanks[1].Word, "как");
			Assert.AreEqual(wordRanks[2].Word, "дела");
	      wordRanks = manager.GetWordRanks<WordRank>(t => t.TotalCount, 2);
			Assert.AreEqual(wordRanks.Count, 2);
			Assert.AreEqual(wordRanks[0].Word, "как");
			Assert.AreEqual(wordRanks[1].Word, "привет");
      }

      [TestMethod]
      public void CalculateRanksTest_CheckPhaseRank()
      {
	      var repository = new Repositories(AppDomain.CurrentDomain.BaseDirectory);
	      repository.FileWordsStore.LoadWordsDictionary();
			repository.MessagesStore.AddMessageItem(new MessageItem(){Message = "Привет как дела"});
			repository.MessagesStore.AddMessageItem(new MessageItem(){Message = "Привет как как как как как"});
			repository.MessagesStore.AddMessageItem(new MessageItem(){Message = "как привет дила"});
			repository.MessagesStore.AddMessageItem(new MessageItem(){Message = "привет дила"});
	      var manager = new ManagerRanks(repository);
			manager.CalculateRanks();
	      var wordRanks = manager.GetPhaseRanks<PhaseRank>(t => t.CountByUniqueMessage, 5);
			Assert.AreEqual(wordRanks.Count, 3);
			Assert.AreEqual(wordRanks[0].Phase, "привет как");
			Assert.AreEqual(wordRanks[1].Phase, "как дела");
			Assert.AreEqual(wordRanks[2].Phase, "как как");
	      wordRanks = manager.GetPhaseRanks<PhaseRank>(t => t.TotalCount, 2);
			Assert.AreEqual(wordRanks.Count, 2);
			Assert.AreEqual(wordRanks[0].Phase, "как как");
			Assert.AreEqual(wordRanks[1].Phase, "привет как");
      }
   }
}
