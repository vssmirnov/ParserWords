using ParserComments.DAL.Stores;

namespace ParserComments.DAL
{
   public interface IRepositories
   {
	   void Load();
		IFileWordsStore FileWordsStore { get; }
		IMistakeWordsStore MistakeWordsStore { get; }
		IMessagesStore MessagesStore { get; }
   }
}
