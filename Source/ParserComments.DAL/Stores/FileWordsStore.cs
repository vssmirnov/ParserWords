using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ParserComments.DAL.Models;

namespace ParserComments.DAL.Stores
{
	public class FileWordsStore : IFileWordsStore
	{
		private readonly string _path;
		private IList<WordItem> _wordItems;

		public FileWordsStore(string path)
		{
			_path = path;
			_wordItems = new List<WordItem>();
		}

		public IList<WordItem> WordItems
		{
			get { return _wordItems; }
		}

		private static string _fileName = "words.txt";

		public void LoadWordsDictionary()
		{
			try
			{
            var fileDictionary = Path.Combine(_path, _fileName);
				if (!File.Exists(fileDictionary))
				{
					return;
				}

				string[] words = File.ReadAllLines(fileDictionary);
				var id = 1;
				foreach (var word in words)
				{
					AddWordToDicitionary(word, id++);
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public string GetWordById(int wordId)
		{
			return _wordItems?.FirstOrDefault(t => t != null && t.Id == wordId)?.Word ?? String.Empty;
		}

		public WordItem SearchWordItem(string word)
		{
			return string.IsNullOrEmpty(word) ? null : WordItems.FirstOrDefault(t => t.Word.Equals(word));
		}

		private void AddWordToDicitionary(string dicionaryItem, int id)
		{
			if (dicionaryItem == null)
			{
				Console.WriteLine("Строка не содержит значения");
				return;
			}

			_wordItems.Add(new WordItem
			{
				Id = id,
				Word = dicionaryItem.Split(' ')[0].Trim()
			});
		}
	}
}