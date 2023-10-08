using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using RAAMEN.Handler;

namespace RAAMEN.Repository {
	public class registRepository {

		public static localDBEntities db = new localDBEntities();

		public static void addUser(string username, string email, string gender, string password, string selectedRole) {

			// call handler to insert into parsed DB localDBEntities

			regisHandler.addUser(username, email, gender, password, selectedRole, db);

		}

	}
}