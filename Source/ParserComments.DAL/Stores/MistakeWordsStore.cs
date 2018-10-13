using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ParserComments.DAL.Models;

namespace ParserComments.DAL.Stores
{
	public class MistakeWordsStore: IMistakeWordsStore
   {
	   private readonly string _path;
	   private static string _fileName = "synonyms.txt";

      private IList<MisstakeWordItem> _misstakeWordItems;

		private int CountItems => _misstakeWordItems.Count;

	   public MistakeWordsStore(string path)
	   {
		   _path = path;
		   _misstakeWordItems = new List<MisstakeWordItem>();
	   }

	   public IList<MisstakeWordItem> MistakeWordItems => _misstakeWordItems;

      public void LoadMistakeWords()
	   {
		   try
		   {
			   var fileDictionary = Path.Combine(_path, _fileName);
			   if (!File.Exists(fileDictionary))
			   {
				   return;
			   }

			   string[] mistakeString = File.ReadAllLines(fileDictionary);
			   foreach (var misstake in mistakeString)
			   {
				   AddMistakeWordItem(misstake);
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

	   public MisstakeWordItem SearchMistakeItem(string misstake)
	   {
		   return _misstakeWordItems.FirstOrDefault(t => t.Misstake.Equals(misstake));
	   }

	   public void SaveMistakeWords()
	   {
		   try
		   {
			   var misstakeDictionary = Path.Combine(_path, _fileName);
			   if (!File.Exists(misstakeDictionary))
			   {
				   Console.WriteLine("Файл не найден");
				   return;
			   }

			   var json = JsonConvert.SerializeObject(_misstakeWordItems);

				File.WriteAllText(misstakeDictionary, json);
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

	   private void AddMistakeWordItem(string misstakes)
	   {
		   var items = JsonConvert.DeserializeObject<List<MisstakeWordItem>>(misstakes);
		   if (items == null) return;
		   foreach (var item in items)
		   {
			   _misstakeWordItems.Add(item);
		   }
      }

	   public void AddMistakeWordItem(string misstake, int wordId)
	   {
			if (_misstakeWordItems.Any(t => t.Misstake.Equals(misstake))) return;

		   var mistakeItem = new MisstakeWordItem()
		   {
			   Id = CountItems + 1,
			   Misstake = misstake,
			   WordItemId = wordId
		   };

			_misstakeWordItems.Add(mistakeItem);
	   }
   }
}
