using RAAMEN.Factory.Shared;
using RAAMEN.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Handler.Shared {
	public class insertRamenHandler {

		// call factory, check for the selected meat first
		public static void addRamen(string name, string meat, string broth, string price, localDBEntities db) {

			if(meat.Equals("Pork")) {

				// call factory, select Pork meat ID
				RamenDetail newRamen = insertRamenFactory.newRamen(name, broth, price, 1);
				db.RamenDetails.Add(newRamen);
				db.SaveChanges();

			}
			
			else if(meat.Equals("Beef")) {

				RamenDetail newRamen = insertRamenFactory.newRamen(name, broth, price, 2);
				db.RamenDetails.Add(newRamen);
				db.SaveChanges();

			}

			else if(meat.Equals("Chicken")) {

				RamenDetail newRamen = insertRamenFactory.newRamen(name, broth, price, 3);
				db.RamenDetails.Add(newRamen);
				db.SaveChanges();

			}
			
		}


	}
}