using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserComments.BL
{
   public interface ISeparatingUserMessage
   {
	   IList<string> Words { get; }

	   IList<Tuple<string, string>> PharseWords { get; }

	   void SeparateMessage(string message);
   }
}
