using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserComments.BL.Models;
using ParserComments.DAL;
using ParserComments.DAL.Models;

namespace ParserComments.BL
{
   public class ManagerMessages: IManagerMessages
   {
	   private readonly IRepositories _repositories;

	   public ManagerMessages(IRepositories repositories)
	   {
		   _repositories = repositories;
	   }

	   public void AddMessage(IMessageModel message)
	   {
		   _repositories?.MessagesStore?.AddMessageItem(new MessageItem
		   {
			   UserName = message.UserName,
			   Email = message.Email,
			   Message = message.Message,
			   SentDate = message.SentDate
		   });
			_repositories?.MessagesStore?.SaveMessages();
	   }

	   public IList<T> GetMessageItems<T>() where T: IMessageModel, new()
	   {
		   return _repositories?.MessagesStore?.Messages.Select(t =>
			   new T {Email = t.Email, Message = t.Message, UserName = t.UserName, SentDate = t.SentDate}).ToList();
	   }
   }
}
