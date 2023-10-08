using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Factory {
	public class regisFactory {

		public static User newUser(string username, string email, string gender, string password, int role) {
		
			User newUser = new User();
			newUser.Username = username;
			newUser.Email = email;
			newUser.Gender = gender;
			newUser.Password = password;
			newUser.roleID = role;

			return newUser;
		
		}

	}
}