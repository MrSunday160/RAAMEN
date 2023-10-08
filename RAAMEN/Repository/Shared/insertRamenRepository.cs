using RAAMEN.Handler.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Factory.Shared;

namespace RAAMEN.Repository.Shared {
	public class insertRamenRepository {

		public static localDBEntities db = new localDBEntities();

		public static void addRamen(string name, string meat, string broth, string price) {

			// call handler
			insertRamenHandler.addRamen(name, meat, broth, price, db);

		}
		

	}
}