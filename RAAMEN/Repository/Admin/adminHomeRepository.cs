using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Admin {
	public class adminHomeRepository {

		public static localDBEntities db = new localDBEntities();

		public static List<User> getAllStaff() {

			return (from x in db.Users where x.roleID == 1 select x).ToList();

		}

	}
}