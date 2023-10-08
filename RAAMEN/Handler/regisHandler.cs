using RAAMEN.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Repository;
using System.Diagnostics.Eventing.Reader;

namespace RAAMEN.Handler
{
	public class regisHandler
	{

		public static void addUser(string username, string email, string gender, string password, string selectedRole, localDBEntities db) {

			// check role selected
			if(selectedRole.Equals("Staff")) {

				User newUser = regisFactory.newUser(username, email, gender, password, 1); // call factory, set as Staff role
				db.Users.Add(newUser);
				db.SaveChanges();

			}


			else if(selectedRole.Equals("Member")) {

				User newUser = regisFactory.newUser(username, email, gender, password, 2); // call factory, set as Member role
				db.Users.Add(newUser);
				db.SaveChanges();

			}

		}

	}
}