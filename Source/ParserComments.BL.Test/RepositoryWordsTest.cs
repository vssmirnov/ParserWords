using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserComments.BL.Test
{
   [TestClass]
   public class RepositoryWordsTest
   {
      [TestMethod]
      public void LoadDictionaryTest()
      {
	      var repository = new Repositories(AppDomain.CurrentDomain.BaseDirectory);
	      repository.FileWordsStore.LoadWordsDictionary();
	      var dictionary = repository.FileWordsStore.WordItems;
			Assert.IsTrue(dictionary.Count > 0);
			Assert.IsTrue(dictionary[1].Id == 2);
			Assert.IsTrue(dictionary[1].Word == "аарона");
      }
   }
}
