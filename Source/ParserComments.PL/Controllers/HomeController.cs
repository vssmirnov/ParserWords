using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParserComments.BL;
using ParserComments.BL.Models;
using ParserComments.PL.Models;

namespace ParserComments.PL.Controllers
{
   public class HomeController : Controller
   {
	   private readonly IManagerMessages _managerMessages;
	   private readonly IManagerRanks _managerRanks;
	   private readonly IManagerMisstake _managerMisstake;

	   public HomeController(IManagerMessages managerMessages, IManagerRanks managerRanks, IManagerMisstake managerMisstake)
	   {
		   _managerMessages = managerMessages;
		   _managerRanks = managerRanks;
		   _managerMisstake = managerMisstake;
	   }

      public ActionResult Messages()
      {
	      return View(GetMessageModels());
      }

	   private List<MessageModel> GetMessageModels()
	   {
		   return _managerMessages.GetMessageItems<MessageModel>().Take(10).ToList();
      }

	   public ActionResult Ranks()
      {
			_managerRanks.CalculateRanks();
	      return View(new RankViewModel()
	      {
		      PhaseRankUniqueMessageModels = GetPhaseRankUniqueMessageModels(),
		      WordRankUniqueMessageModels = GetWordRankUniqueMessageModels(),
		      PhaseRankTotalModels = GetPhaseRankTotalModels(),
		      WordRankTotalModels = GetWordRankTotalModels()
	      });
      }

	   private List<WordRankModel> GetWordRankTotalModels()
	   {
		   return _managerRanks.GetWordRanks<WordRankModel>(t => t.TotalCount, 5);
	   }

	   private List<PhaseRankModel> GetPhaseRankTotalModels()
	   {
		   return _managerRanks.GetPhaseRanks<PhaseRankModel>(t => t.TotalCount, 5);
      }

	   private List<WordRankModel> GetWordRankUniqueMessageModels()
	   {
		   return _managerRanks.GetWordRanks<WordRankModel>(t => t.CountByUniqueMessage, 5);
	   }

	   private List<PhaseRankModel> GetPhaseRankUniqueMessageModels()
	   {
		   return _managerRanks.GetPhaseRanks<PhaseRankModel>(t => t.CountByUniqueMessage, 5);
	   }

      public ActionResult Misstakes()
      {
	      _managerMisstake.UpdateData();
         return View(_managerMisstake.GetMisstake<MisstakeModel>(10));
      }

	   public ActionResult SaveMisstake(FormCollection form)
	   {
		   if (form == null) return View("Misstakes", _managerMisstake.GetMisstake<MisstakeModel>(10));

		   foreach (var key in form.AllKeys)
		   {
			   _managerMisstake.AddMisstake(key, form[key]);
         }

		   if (form.AllKeys.Any())
		   {
			   _managerMisstake.SaveMisstakes();
         }

			return View("Misstakes", _managerMisstake.GetMisstake<MisstakeModel>(10));
      }


      public ActionResult Contact(FormCollection form)
		{
			if (form == null) return View("Messages", GetMessageModels());

			_managerMessages?.AddMessage(new MessageModel()
			{
				UserName = form["userName"],
				Email = form["email"],
				Message = form["message"],
				SentDate = DateTime.Now
			});

			return View("Messages", GetMessageModels());
		}
   }
}