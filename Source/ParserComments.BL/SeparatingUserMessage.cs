using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParserComments.BL
{
   public class SeparatingUserMessage : ISeparatingUserMessage
   {
	   private string _sourceMessage;

	   public SeparatingUserMessage()
	   {
		   Words = new List<string>();
		   PharseWords = new List<Tuple<string, string>>();
      }

	   public IList<string> Words { get; private set; }

      public IList<Tuple<string, string>> PharseWords { get; private set; }

	   public void SeparateMessage(string message)
	   {
		   _sourceMessage = message ?? string.Empty;
         var sentences = _sourceMessage.Split('.', '!', '?');
		   foreach (var sentence in sentences)
		   {
			   AddWordsToUniqueWords(sentence.ToLower());
			   AddPharseToWords(sentence.ToLower());
         }
	   }

	   private void AddWordsToUniqueWords(string sentence)
	   {
         Regex regex = new Regex(@"([а-я]{1,})");
		   Match match = regex.Match(sentence);
		   while (match.Success)
		   {
            Words.Add(match.Value);
			   match = match.NextMatch();
		   }
	   }

	   private void AddPharseToWords(string sentence)
	   {
         var regex = new Regex(@"([а-я]{1,})");
		   var match = regex.Match(sentence);

         while (match.Success)
		   {
			   var firstWord = match.Value;
			   match = match.NextMatch();

			   if (!match.Success)
			   {
				   return;
			   }

			   var secondWord = match.Value;
			   PharseWords.Add(new Tuple<string, string>(firstWord, secondWord));
         }
	   }
   }
}
