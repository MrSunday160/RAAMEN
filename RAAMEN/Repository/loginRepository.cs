using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace RAAMEN.Repository {
	public class loginRepository {

		public static localDBEntities db = new localDBEntities();

		public static string getRoles(string username) {

			// refactored from using 2 variables to 1
			// use LINQ to join 2 table on same ID where username is matching with parameter
			string roles = (from x in db.Users join y in db.Roles on x.roleID equals y.ID where x.Username == username select y.Name).FirstOrDefault(); 

			return roles;

		}

		public static int getId(string username){

			int roles = (from x in db.Users where x.Username == username select x.ID).FirstOrDefault();

			return roles;


		}

		public static bool checkUser(string username, string password) {

			// var user = db.Users.FirstOrDefault(x => x.Username == username);
			User user = (from x in db.Users where x.Username == username select x).FirstOrDefault(); // get user table from db, compare with LINQ

			if(user != null) { // if username found

				if(password.Equals(user.Password)) {

					//Debug.WriteLine("true");
					return true;

				}


				else {

					//Debug.WriteLine("false");
					return false;

				}

			}

			else
				return false;


		}

	}
}