using RAAMEN.Handler.Staff;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Staff {
	public class profileRepository {

		public static localDBEntities db = new localDBEntities();

		public static bool confirmPassword(string password, int userId) {

			string userPassword = (from x in db.Users where x.ID == userId select x.Password).FirstOrDefault();

			if(userPassword == password) {

				Debug.WriteLine("password match");
				return true;

			}

			else {

				Debug.WriteLine("passowrd dont match");
				return false;

			}

		}

		public static void updateProfile(string username, string email, string gender, int userId) {

			// call handler to update
			profileHandler.updateProfile(username, email, gender, userId, db);

		}

		public static List<User> getUser(int userId) {

			return (from x in db.Users where x.ID == userId select x).ToList();

		}

	}
}