using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RAAMEN.Handler.Shared {
	public class manageRamenHandler {

		public static string deleteRamen(RamenDetail ramenTemp, localDBEntities db) {

			

			try {

				var detailRemove = (from x in db.Details where x.ramenID == ramenTemp.ID select x).FirstOrDefault();

				if(detailRemove != null)
					db.Details.Remove(detailRemove);


				db.RamenDetails.Remove(ramenTemp);
				db.SaveChanges();

				return "Delete Successful";

			}
			catch {

				Debug.WriteLine("Ramen is used on other table, or error occurred");

				return "Delete failed, ramen may be ordered already";

			}

		}

	}
}