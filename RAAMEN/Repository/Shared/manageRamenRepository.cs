using RAAMEN.Handler.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace RAAMEN.Repository.Shared {
	public class manageRamenRepository {

		public static localDBEntities db = new localDBEntities();

		public static List<RamenDetail> getAllRamenDetails() {

			//Debug.WriteLine("get all data");
			return db.RamenDetails.ToList();
		
		}

		public static RamenDetail getById(int id) {

			return (from x in db.RamenDetails where x.ID == id select x).FirstOrDefault();

		}

		public static string deleteById(RamenDetail ramenTemp) {

			// call handler to do the deletion
			return manageRamenHandler.deleteRamen(ramenTemp, db);

		}

	}
}