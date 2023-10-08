using RAAMEN.Factory.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RAAMEN.Handler.Shared {
	public class updateRamenHandler {

		public static void updateRamen(string name, string meat, string broth, string price, localDBEntities db, int id) {

			RamenDetail ramenDetail = (from x in db.RamenDetails where x.ID == id select x).FirstOrDefault();

			ramenDetail.Name = name;

			// check selected meat
			if(meat.Equals("Pork"))
				ramenDetail.meatID = 1;

			else if(meat.Equals("Beef"))
				ramenDetail.meatID = 2;

			else if(meat.Equals("Chicken"))
				ramenDetail.meatID = 3;

			ramenDetail.Broth = broth;
			ramenDetail.Price = price;

			db.SaveChanges();

			Debug.WriteLine("update done");

		}

	}
}