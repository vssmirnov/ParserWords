using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParserComments.BL;
using ParserComments.BL.Models;

namespace ParserComments.PL.Models
{
   public class PhaseRankModel: IPhaseRankModel
   {
	   public int TotalCount { get; set; }
	   public int CountByUniqueMessage { get; set; }
	   public string Phase { get; set; }
   }
}