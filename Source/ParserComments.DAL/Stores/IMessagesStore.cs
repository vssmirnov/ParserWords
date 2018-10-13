using System.Collections.Generic;
using ParserComments.DAL.Models;

namespace ParserComments.DAL.Stores
{
   public interface IMessagesStore
   {
	   IList<MessageItem> Messages { get; }
	   void LoadMessages();
	   void SaveMessages();
	   void AddMessageItem(MessageItem messageItem);
   }
}
