using System;

namespace ParserComments.DAL.Models
{
   public class MessageItem
   {
	   public string UserName { get; set; }
	   public string Email { get; set; }
	   public string Message { get; set; }
	   public DateTime SentDate { get; set; }
   }
}
