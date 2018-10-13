using System;
using System.Collections.Generic;
using ParserComments.BL.Models;

namespace ParserComments.BL
{
	public interface ICalculatorRank
	{
		IList<WordRank> WordRanks { get; }
		IList<PhaseRank> PhaseRanks { get; }

		void CalculateRankByMessage(IList<FindedItem> findedWords,
			IList<Tuple<FindedItem, FindedItem>> findedPhases);
	}
}