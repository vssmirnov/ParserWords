using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParserComments.PL.Models
{
   public class RankViewModel
   {
	   public IList<PhaseRankModel> PhaseRankUniqueMessageModels { get; set; }
	   public IList<WordRankModel> WordRankUniqueMessageModels { get; set; }
	   public IList<PhaseRankModel> PhaseRankTotalModels { get; set; }
	   public IList<WordRankModel> WordRankTotalModels { get; set; }
   }
}