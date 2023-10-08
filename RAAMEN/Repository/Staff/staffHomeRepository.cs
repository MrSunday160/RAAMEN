using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Staff {
	public class staffHomeRepository {

		public static localDBEntities db = new localDBEntities();

		public static List<User> getAllMember() {

			return (from x in db.Users where x.roleID == 2 select x).ToList();

		} 
	}
}