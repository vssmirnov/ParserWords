using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserComments.BL.Models;

namespace ParserComments.BL
{
   public interface IManagerRanks
   {
	   List<T> GetWordRanks<T>(Func<WordRank, int> sortFunc, int countWords) where T : IWordRankModel, new();
	   List<T> GetPhaseRanks<T>(Func<PhaseRank, int> sortFunc, int countPhases) where T : IPhaseRankModel, new();
	   void CalculateRanks();
   }
}
