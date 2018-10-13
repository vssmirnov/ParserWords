namespace ParserComments.BL.Models
{
   public interface IWordRankModel
   {
	   int TotalCount { get; set; }
	   int CountByUniqueMessage { get; set; }
	   string Word { get; set; }
   }
}
