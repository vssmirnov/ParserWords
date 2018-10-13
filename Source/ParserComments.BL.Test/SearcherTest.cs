using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserComments.DAL;

namespace ParserComments.BL.Test
{
   [TestClass]
   public class SearcherTest
   {
      [TestMethod]
      public void SearchTest()
      {
			IRepositories repositories = new Repositories(AppDomain.CurrentDomain.BaseDirectory);
			repositories.Load();
	      var searcher = new Searcher(repositories);
	      searcher.Search(new List<string>() {"привет", "как", "дила"},
		      new List<Tuple<string, string>>()
		      {
			      new Tuple<string, string>("привет", "как"),
			      new Tuple<string, string>("как", "дила")
		      });
			Assert.AreEqual(searcher.FindedWords.Count, 2);
			Assert.AreEqual(searcher.FindedPhaseses.Count, 1);
      }
   }
}
