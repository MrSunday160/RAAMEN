using RAAMEN.Repository.Member;
using RAAMEN.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace RAAMEN.Factory.Member {
	public class cartFactory {

		public static cartViewModel newItem(string ramenId, string qty) { // call viewmodel to get data variables

			cartViewModel newItem = new cartViewModel();
			cartViewModel dataTemp = cartRepository.getData(ramenId); // call repository to hold data from db

			newItem.ramenID = dataTemp.ramenID;
			newItem.ramenName = dataTemp.ramenName;
			newItem.Broth = dataTemp.Broth;
			newItem.Price = dataTemp.Price;
			newItem.Quantity = int.Parse(qty);
			newItem.meatID = dataTemp.meatID;
			newItem.meatName = dataTemp.meatName;


			return newItem;

		}

	}
}