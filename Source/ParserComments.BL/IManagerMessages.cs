using System.Collections.Generic;
using ParserComments.BL.Models;

namespace ParserComments.BL
{
   public interface IManagerMessages
   {
	   void AddMessage(IMessageModel message);
	   IList<T> GetMessageItems<T>() where T : IMessageModel, new();
   }
}
