using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserComments.BL.Models;
using ParserComments.DAL;

namespace ParserComments.BL
{
	public class Searcher
	{
		private readonly IRepositories _repositories;
		private IList<FindedItem> _findedWords;
		private IList<Tuple<FindedItem, FindedItem>> _findedPhases;

		public Searcher(IRepositories repositories)
		{
			_repositories = repositories;
			_findedWords = new List<FindedItem>();
			_findedPhases = new List<Tuple<FindedItem, FindedItem>>();
		}

		public IList<FindedItem> FindedWords => _findedWords;
		public IList<Tuple<FindedItem, FindedItem>> FindedPhaseses => _findedPhases;

		private void SearchWord(IList<string> sourceWords)
		{
			if (sourceWords == null) return;
			foreach (var sourceWord in sourceWords)
			{
				var findWord = FindWord(sourceWord);
				if (findWord != null)
				{
					_findedWords.Add(findWord);
					continue;
				}

				findWord = FindMisstake(sourceWord);
				if (findWord != null)
				{
					_findedWords.Add(findWord);
					continue;
				}

				_repositories.MistakeWordsStore.AddMistakeWordItem(sourceWord, 0);
         }
		}

		private FindedItem FindMisstake(string sourceWord)
		{
			var misstake = _repositories.MistakeWordsStore.SearchMistakeItem(sourceWord);
			if (misstake == null || misstake.WordItemId == 0)
			{
				Console.WriteLine($"Слово {sourceWord} в словаре ошибок не найдено");
				return null;
			}
			else
			{
				return new FindedItem()
				{
					SourceType = SourceType.MisstakeDicionary,
					WordItemId = misstake.WordItemId,
					SourceWord = sourceWord
				};
			}
		}

		public void Search(IList<string> sourceWords, IList<Tuple<string, string>> sourcePhase)
		{
			SearchWord(sourceWords);
			SearchPhase(sourcePhase);
		}

		private void SearchPhase(IList<Tuple<string, string>> sourcePhases)
		{
			if (sourcePhases == null) return;
			foreach (var sourceWord in sourcePhases)
			{
				var findedFirstItem = FindWord(sourceWord.Item1);
				var findedSecondItem = FindWord(sourceWord.Item2);

				if (findedFirstItem != null && findedSecondItem != null)
				{
					_findedPhases.Add(new Tuple<FindedItem, FindedItem>(findedFirstItem, findedSecondItem));
					continue;
				}

				if (findedFirstItem == null)
				{
					findedFirstItem = FindMisstake(sourceWord.Item1);
				}

				if (findedSecondItem == null)
				{
					findedSecondItem = FindMisstake(sourceWord.Item2);
				}

				if (findedFirstItem != null && findedSecondItem != null)
				{
					_findedPhases.Add(new Tuple<FindedItem, FindedItem>(findedFirstItem, findedSecondItem));
				}
			}
		}

		private FindedItem FindWord(string sourceWord)
		{
			var firstWordItem = _repositories.FileWordsStore.SearchWordItem(sourceWord);

			if (firstWordItem == null)
			{
				Console.WriteLine($"Слово {sourceWord} в словаре не найдено");
				return null;
			}
			else
			{
				return new FindedItem()
				{
					SourceType = SourceType.WordDicionary,
					WordItemId = firstWordItem.Id,
					SourceWord = sourceWord
				};
			}
		}
	}
}