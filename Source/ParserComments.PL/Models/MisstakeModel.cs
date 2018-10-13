using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParserComments.BL.Models;

namespace ParserComments.PL.Models
{
   public class MisstakeModel: IMisstakeModel
   {
	   public int Id { get; set; }
	   public string Misstake { get; set; }
	   public int WordItemId { get; set; }
   }
}