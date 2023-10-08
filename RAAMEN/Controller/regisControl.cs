using RAAMEN.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RAAMEN.Controller {
	public class regisControl {

		public static int validateBtn(string username, string email, string gender, string password, string passConfirm, string selectedRole) {

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

			if(passConfirm.Equals("")) // passConfirm empty
				return 6;

			if(!(password.Equals(passConfirm))) // passwords does not match
				return 7;

			if(selectedRole.Equals("")) // radio empty
				return 8;

			else {

				// open access from repository to handler to add to db
				registRepository.addUser(username, email, gender, password, selectedRole);

				return 9;

			}

		}

	}
}