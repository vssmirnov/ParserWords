using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserComments.BL.Models;

namespace ParserComments.BL
{
   public interface ISearcher
   {
	   IList<FindedItem> FindedWords { get; }
	   IList<Tuple<FindedItem, FindedItem>> FindedPhaseses { get; }
	   void Search();
   }
}
