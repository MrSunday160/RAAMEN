using RAAMEN.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Member {
	public class cartRepository {

		public static localDBEntities db = new localDBEntities();

		public static List<cartViewModel> getCartData(int id, int qty) {

			return (from x in db.RamenDetails join y in db.Meats on x.meatID equals y.ID where x.ID == id select new cartViewModel {

				ramenID = x.ID,
				Quantity = qty,
				meatID = y.ID,
				meatName = y.Name,
				ramenName = x.Name,
				Broth = x.Broth,
				Price = x.Price

			}).ToList();

		}

		public static cartViewModel getData(string id) {

			int tempId = int.Parse(id);

			return (from x in db.RamenDetails join y in db.Meats on x.meatID equals y.ID where x.ID == tempId select new cartViewModel {

				ramenID = x.ID,
				meatID = y.ID,
				meatName = y.Name,
				ramenName = x.Name,
				Broth = x.Broth,
				Price = x.Price

			}).FirstOrDefault();

		}

	}
}