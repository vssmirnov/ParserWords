using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Ninject.Modules;
using ParserComments.BL;
using ParserComments.BL.Models;

namespace ParserComments.PL.Util
{
   public class NinjectRegistration : NinjectModule
   {
	   public override void Load()
	   {
		   var repositories = new Repositories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin"));
			repositories.Load();
		   Bind<IManagerMessages>().To<ManagerMessages>().InSingletonScope().WithConstructorArgument("repositories", repositories);
			Bind<IManagerRanks>().To<ManagerRanks>().InSingletonScope().WithConstructorArgument("repositories", repositories);
			Bind<IManagerMisstake>().To<ManagerMisstake>().InSingletonScope().WithConstructorArgument("repositories", repositories);
      }
   }
}