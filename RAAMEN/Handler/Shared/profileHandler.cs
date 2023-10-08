using RAAMEN.Repository.Staff;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RAAMEN.Handler.Staff {
	public class profileHandler {

		public static void updateProfile(string username, string email, string gender, int userId, localDBEntities db) {

			User user = (from x in db.Users where x.ID == userId select x).FirstOrDefault(); // hold current user with the userId
			user.Username = username;
			user.Email = email;
			user.Gender = gender;
			db.SaveChanges();

			Debug.WriteLine("update complete");

		}

	}
}