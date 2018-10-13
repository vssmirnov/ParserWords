using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserComments.DAL.Stores;

namespace ParserComments.DAL.Test.Stores
{
   [TestClass]
   public class MistakeWordsStoreTest
   {
      [TestMethod]
      public void SaveMistakeWordsTest()
      {
	      IMistakeWordsStore mistakeWordsStore = new MistakeWordsStore(AppDomain.CurrentDomain.BaseDirectory);
	      var misstake = "Привт";
	      mistakeWordsStore.AddMistakeWordItem(misstake, 1);
			mistakeWordsStore.SaveMistakeWords();
			mistakeWordsStore.LoadMistakeWords();
	      var mistake = mistakeWordsStore.MistakeWordItems;
			Assert.AreEqual(mistake.Count, 1);
			Assert.AreEqual(mistake[0].Id, 1);
			Assert.AreEqual(mistake[0].WordItemId, 1);
			Assert.AreEqual(mistake[0].Misstake, misstake);

      }
   }
}
