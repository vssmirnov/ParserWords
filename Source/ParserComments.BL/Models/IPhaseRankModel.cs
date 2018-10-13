namespace ParserComments.BL.Models
{
   public interface IPhaseRankModel
   {
	   int TotalCount { get; set; }
	   int CountByUniqueMessage { get; set; }
	   string Phase { get; set; }
   }
}
