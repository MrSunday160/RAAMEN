using RAAMEN.Repository;
using RAAMEN.Handler.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using RAAMEN.Repository.Staff;

namespace RAAMEN.Controller.Staff {
	public class profileControl {

		public static int validateBtn(string username, string email, string gender, string password, int userId) {

			if(username.Equals("")) // username empty
				return 0;

			if(username.Length < 5 || username.Length > 15 || !Regex.IsMatch(username, "^[a-zA-Z]+$")) // username between 5 - 15, only alphabets
				return 1;

			if(email.Equals(""))
				return 2;

			if(!email.EndsWith(".com")) // email ends with .com
				return 3;

			if(gender.Equals("")) // gender empty
				return 4;

			if(password.Equals("")) //password empty
				return 5;

			// call repository to check passwrod with db
			if(profileRepository.confirmPassword(password, userId) == false) // not match
				return 6;

			if(profileRepository.confirmPassword(password, userId) == true) { // match

				// call repository
				profileRepository.updateProfile(username, email, gender, userId);

				return 7;

			}

			return 8; // something went wrong?

		}

	}
}