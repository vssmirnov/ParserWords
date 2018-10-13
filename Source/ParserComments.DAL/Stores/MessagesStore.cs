using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ParserComments.DAL.Models;

namespace ParserComments.DAL.Stores
{
   public class MessagesStore : IMessagesStore
   {
	   private string _fileName = "messages.txt";
	   private readonly string _path;

	   private IList<MessageItem> _messageItems;

	   private int CountItems => _messageItems.Count;

      public MessagesStore(string path)
      {
	      _path = path;
		   _messageItems = new List<MessageItem>();
	   }

	   public IList<MessageItem> Messages => _messageItems;

	   public void LoadMessages()
	   {
		   try
		   {
			   var fileDictionary = Path.Combine(_path, _fileName);
			   if (!File.Exists(fileDictionary))
			   {
				   return;
			   }

			   string[] messages = File.ReadAllLines(fileDictionary);
			   foreach (var message in messages)
			   {
				   AddMessageItem(message);
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

	   public void SaveMessages()
	   {
		   try
		   {
			   var messages = Path.Combine(_path, _fileName);
			   if (!File.Exists(messages))
			   {
				   Console.WriteLine("Файл не найден");
				   return;
			   }

			   var json = JsonConvert.SerializeObject(_messageItems);

			   File.WriteAllText(messages, json);
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

      private void AddMessageItem(string misstake)
	   {
		   var items = JsonConvert.DeserializeObject<IList<MessageItem>>(misstake);
		   if (items == null) return;
		   foreach (var item in items)
		   {
			   _messageItems.Add(item);
         }
	   }

	   public void AddMessageItem(MessageItem messageItem)
	   {
		   _messageItems.Add(messageItem);
	   }
   }
}
