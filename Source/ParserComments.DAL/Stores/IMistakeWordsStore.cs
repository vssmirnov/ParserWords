using System.Collections.Generic;
using ParserComments.DAL.Models;

namespace ParserComments.DAL.Stores
{
   public interface IMistakeWordsStore
   {
	   MisstakeWordItem SearchMistakeItem(string misstake);
		IList<MisstakeWordItem> MistakeWordItems { get; }
	   void LoadMistakeWords();
	   void SaveMistakeWords();
	   void AddMistakeWordItem(string misstakes, int wordId);
   }
}
