using System;
using System.Collections.Generic;
using System.Linq;
using ParserComments.BL.Models;
using ParserComments.DAL;

namespace ParserComments.BL
{
	public class ManagerMisstake: IManagerMisstake
   {
		private readonly IRepositories _repositories;

		public ManagerMisstake(IRepositories repositories)
		{
			_repositories = repositories;
		}

		public List<T> GetMisstake<T>(int countMisstake) where T : IMisstakeModel, new()
		{
			return _repositories.MistakeWordsStore.MistakeWordItems.Where(t => t.WordItemId == 0).Take(countMisstake)
				.Select(t => new T() {Misstake = t.Misstake, Id = t.Id}).ToList();
		}

	   public void AddMisstake(string idValue, string wordSource)
	   {
		   if (!int.TryParse(idValue, out var id)) return;

		   var misstake = _repositories.MistakeWordsStore.MistakeWordItems.FirstOrDefault(t => t.Id == id);

		   if (misstake == null) return;

		   var word = _repositories.FileWordsStore.SearchWordItem(wordSource);

		   if (word == null) return;

		   misstake.WordItemId = word.Id;
	   }

	   public void SaveMisstakes() 
	   {
		   _repositories.MistakeWordsStore.SaveMistakeWords();
	   }

	   public void UpdateData()
	   {
		   foreach (var message in _repositories.MessagesStore.Messages)
		   {
			   var separatingMessage = new SeparatingUserMessage();
			   var searcher = new Searcher(_repositories);
			   separatingMessage.SeparateMessage(message.Message);
			   searcher.Search(separatingMessage.Words, separatingMessage.PharseWords);
		   }
	   }

   }
}
