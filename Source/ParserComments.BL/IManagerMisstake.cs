using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserComments.BL.Models;

namespace ParserComments.BL
{
   public interface IManagerMisstake
   {
	   List<T> GetMisstake<T>(int countMisstake) where T : IMisstakeModel, new();
	   void AddMisstake(string idValue, string wordSource);
      void SaveMisstakes();
	   void UpdateData();
   }
}
