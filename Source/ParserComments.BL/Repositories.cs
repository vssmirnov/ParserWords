using ParserComments.DAL;
using ParserComments.DAL.Stores;

namespace ParserComments.BL
{
	public class Repositories : IRepositories
	{
		public Repositories(string path)
		{
			FileWordsStore = new FileWordsStore(path);
			MistakeWordsStore = new MistakeWordsStore(path);
			MessagesStore = new MessagesStore(path);
		}

		public void Load()
		{
			FileWordsStore.LoadWordsDictionary();
			MessagesStore.LoadMessages();
			MistakeWordsStore.LoadMistakeWords();
		}

		public IFileWordsStore FileWordsStore { get; }
		public IMistakeWordsStore MistakeWordsStore { get; }
		public IMessagesStore MessagesStore { get; }
	}
}