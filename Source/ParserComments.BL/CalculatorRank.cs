using System;
using System.Collections.Generic;
using System.Linq;
using ParserComments.BL.Models;

namespace ParserComments.BL
{
   public class CalculatorRank : ICalculatorRank
   {
	   private IList<WordRank> _wordRanks;
	   private IList<PhaseRank> _phaseRanks;

	   public CalculatorRank()
	   {
			_wordRanks = new List<WordRank>();
			_phaseRanks = new List<PhaseRank>();
	   }

	   public IList<WordRank> WordRanks => _wordRanks;
	   public IList<PhaseRank> PhaseRanks => _phaseRanks;

	   public void CalculateRankByMessage(IList<FindedItem> findedWords, IList<Tuple<FindedItem, FindedItem>> findedPhases)
	   {
		   CalculateRankWords(findedWords);
			CalculateRankPhases(findedPhases);
	   }

	   private void CalculateRankWords(IList<FindedItem> findedWords)
	   {
		   if (findedWords == null) return;
		   if (_wordRanks == null) return;
         var groups = findedWords.GroupBy(t => t.WordItemId);

         foreach (var group in groups)
		   {
			   var wordRank = _wordRanks.FirstOrDefault(t => t != null && t.WordId == @group.Key);
			   if (wordRank == null)
			   {
				   _wordRanks.Add(new WordRank()
				   {
					   CountByUniqueMessage = 1,
					   TotalCount = @group.Count(),
					   WordId = @group.Key
				   });
				   continue;
			   }

			   wordRank.CountByUniqueMessage++;
			   wordRank.TotalCount += @group.Count();
		   }
	   }

	   private void CalculateRankPhases(IList<Tuple<FindedItem,FindedItem>> findedPhases)
	   {
		   if (findedPhases== null) return;
		   if (_phaseRanks == null) return;
			var tempPhaseRanks = new List<PhaseRank>();

         foreach (var phase in findedPhases)
		   {
			   if (phase?.Item1 == null || phase?.Item2 == null) return;
			   var phaseRank = tempPhaseRanks.FirstOrDefault(t =>
				   t != null && (t.FirstWordId == phase.Item1.WordItemId && t.SecondWordId == phase.Item2.WordItemId ||
				                 t.FirstWordId == phase.Item2.WordItemId && t.SecondWordId == phase.Item1.WordItemId));

			   if (phaseRank == null)
			   {
				   tempPhaseRanks.Add(new PhaseRank()
				   {
					   CountByUniqueMessage = 1,
						TotalCount = 1,
					   FirstWordId = phase.Item1.WordItemId,
					   SecondWordId = phase.Item2.WordItemId,
				   });
				   continue;
			   }

			   phaseRank.TotalCount++;
		   }

		   foreach (var temp in tempPhaseRanks)
		   {
			   var phaseRank = _phaseRanks.FirstOrDefault(t =>
				   t != null && (t.FirstWordId == temp.FirstWordId && t.SecondWordId == temp.SecondWordId ||
				                 t.FirstWordId == temp.SecondWordId && t.SecondWordId == temp.FirstWordId));
			   if (phaseRank == null)
			   {
					_phaseRanks.Add(temp);
					continue;
			   }

			   phaseRank.TotalCount += temp.TotalCount;
			   phaseRank.CountByUniqueMessage++;
		   }
      }
   }
}
