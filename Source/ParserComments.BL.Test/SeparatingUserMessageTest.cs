using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserComments.BL.Test
{
   [TestClass]
   public class SeparatingUserMessageTest
   {
      [TestMethod]
      public void SeparateMessageTest_CheckCount()
      {
	      var text = @"Привет как дела дела дела4? Что делаешь? а че?
							выв";
	      var separatingUserMessage = new SeparatingUserMessage();
			separatingUserMessage.SeparateMessage(text);
	      var uniqWords = separatingUserMessage.Words;
			Assert.AreEqual(uniqWords.Count, 8);
      }

	   [TestMethod]
      public void SeparateMessageTest_CheckEmptyText()
      {
	      var text = "";
	      var separatingUserMessage = new SeparatingUserMessage();
			separatingUserMessage.SeparateMessage(text);
	      var uniqWords = separatingUserMessage.Words;
			Assert.AreEqual(uniqWords.Count, 0);
      }

	   [TestMethod]
      public void SeparateMessageTest_CheckNull()
      {
	      var text = "";
	      var separatingUserMessage = new SeparatingUserMessage();
			separatingUserMessage.SeparateMessage(text);
	      var uniqWords = separatingUserMessage.Words;
			Assert.AreEqual(uniqWords.Count, 0);
      }
   }
}
