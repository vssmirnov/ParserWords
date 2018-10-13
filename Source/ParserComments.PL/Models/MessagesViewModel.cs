using System;
using ParserComments.BL;
using ParserComments.BL.Models;

namespace ParserComments.PL.Models
{
	public class MessageModel: IMessageModel
   {
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Message { get; set; }
		public DateTime SentDate { get; set; }
	}
}