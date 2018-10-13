using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserComments.BL.Models;

namespace ParserComments.BL.Test
{
   [TestClass]
   public class CalculatorRankTest
   {
      [TestMethod]
      public void CalculateRankByMessageTest()
      {
			var calculatorRank = new CalculatorRank();
	      calculatorRank.CalculateRankByMessage(
		      new List<FindedItem>()
		      {
			      new FindedItem() {SourceType = SourceType.WordDicionary, WordItemId = 1, SourceWord = "Test"},
			      new FindedItem() {SourceType = SourceType.WordDicionary, WordItemId = 1, SourceWord = "Test"}
		      },
		      new List<Tuple<FindedItem, FindedItem>>()
		      {
			      new Tuple<FindedItem, FindedItem>(
				      new FindedItem() {SourceType = SourceType.WordDicionary, WordItemId = 1, SourceWord = "Test"},
				      new FindedItem() {SourceType = SourceType.WordDicionary, WordItemId = 2, SourceWord = "Test2"})
		      });
			Assert.AreEqual(calculatorRank.WordRanks.Count, 1);
			Assert.AreEqual(calculatorRank.PhaseRanks.Count, 1);
      }
   }
}
