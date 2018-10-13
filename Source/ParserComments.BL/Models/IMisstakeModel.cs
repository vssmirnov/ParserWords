using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserComments.BL.Models
{
   public interface IMisstakeModel
   {
		int Id { get; set; }
	   string Misstake { get; set; }
	   int WordItemId { get; set; }
   }
}
