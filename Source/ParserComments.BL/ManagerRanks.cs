using System;
using System.Collections.Generic;
using System.Linq;
using ParserComments.BL.Models;
using ParserComments.DAL;

namespace ParserComments.BL
{
   public class ManagerRanks: IManagerRanks
   {
	   private readonly IRepositories _repositories;
	   private ICalculatorRank _calculatorRank;

	   public ManagerRanks(IRepositories repositories)
	   {
		   _repositories = repositories;
		   _calculatorRank = new CalculatorRank();
	   }

	   public List<T> GetWordRanks<T>(Func<WordRank, int> sortFunc, int countWords) where T: IWordRankModel, new()
	   {
		   return _calculatorRank.WordRanks.OrderByDescending(sortFunc).Select(t => new T()
		   {
			   CountByUniqueMessage = t.CountByUniqueMessage,
				Word = _repositories.FileWordsStore.GetWordById(t.WordId),
				TotalCount = t.TotalCount
		   }).Take(countWords).ToList();
	   }

	   public List<T> GetPhaseRanks<T>(Func<PhaseRank, int> sortFunc, int countPhases) where T: IPhaseRankModel, new()
	   {
		   return _calculatorRank.PhaseRanks.OrderByDescending(sortFunc).Select(t =>
		   {
			   var phase = _repositories.FileWordsStore.GetWordById(t.FirstWordId) + " " + _repositories.FileWordsStore.GetWordById(t.SecondWordId);
			   return new T()
			   {
				   CountByUniqueMessage = t.CountByUniqueMessage,
				   Phase = phase,
				   TotalCount = t.TotalCount
			   };
		   }).Take(countPhases).ToList();
	   }

	   public void CalculateRanks()
      { 			
			_calculatorRank = new CalculatorRank();

         foreach (var message in _repositories.MessagesStore.Messages)
		   {
			   var separatingMessage = new SeparatingUserMessage();
			   var searcher = new Searcher(_repositories);
            separatingMessage.SeparateMessage(message.Message);
			   searcher.Search(separatingMessage.Words, separatingMessage.PharseWords);
				_calculatorRank.CalculateRankByMessage(searcher.FindedWords, searcher.FindedPhaseses);
         }
      }
   }
}
