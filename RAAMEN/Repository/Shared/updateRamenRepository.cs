using RAAMEN.Handler.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Shared {
	public class updateRamenRepository {

		public static localDBEntities db =	new localDBEntities();

		public static List<RamenDetail> getById(int id) {
		
			return (from x in db.RamenDetails where x.ID == id select x).ToList();
		
		}

		public static void updateRamen(string name, string meat, string broth, string price, int id) {

			// call handler to update, parse ramenDetail
			updateRamenHandler.updateRamen(name, meat, broth, price, db, id);

		}

	}
}