using RAAMEN.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Controller {
	public class loginControl {

		public static string validateBtn(string username, string password) {

			if(username.Equals("") && password.Equals(""))
				return "All fields cannot be empty";

			else if(username.Equals(""))
				return "Username cannot be empty";

			else if(password.Equals(""))
				return "Password cannot be empty";

			//validation with db, need to connect with repository
			else if(loginRepository.checkUser(username, password) == true) // validate true
				return string.Empty;

			else if(loginRepository.checkUser(username, password) == false) // validate false
				return "Password invalid or user not found";

			else return "Something went wrong";


		}

	}
}