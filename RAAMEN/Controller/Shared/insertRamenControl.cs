using RAAMEN.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RAAMEN.Controller.Shared {
	public class insertRamenControl {

		public static int validateBtn(string name, string meat, string broth, string price) {

			if(name.Equals("") && meat.Equals("") && broth.Equals("") && price.Equals(""))
				return 1;

			if(!Regex.IsMatch(name, @"\bRamen\b")) // regex matching
				return 2;

			if(broth.Equals(""))
				return 3;

			// check for price because uses varchar(50)
			try {

				if(int.Parse(price) < 3000) // price less than 3000
					return 4;

			}
			catch(FormatException) {
			
				return 5;
			
			}

			// call repository
			insertRamenRepository.addRamen(name, meat, broth, price);

			return 6;

		}

	}
}