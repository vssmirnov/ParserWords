using System.Collections.Generic;
using ParserComments.DAL.Models;

namespace ParserComments.DAL.Stores
{
   public interface IFileWordsStore
   {
	   IList<WordItem> WordItems { get; }
	   void LoadWordsDictionary();
	   string GetWordById(int wordId);
		WordItem SearchWordItem(string word);
   }
}
