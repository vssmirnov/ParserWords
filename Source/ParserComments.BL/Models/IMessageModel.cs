using System;

namespace ParserComments.BL.Models
{
   public interface IMessageModel
   {
	   string UserName { get; set; }
	   string Email { get; set; }
	   string Message { get; set; }
	   DateTime SentDate { get; set; }
   }
}
