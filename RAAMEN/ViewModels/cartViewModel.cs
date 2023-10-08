using RAAMEN.Repository.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace RAAMEN.ViewModels {
	public class cartViewModel {

		// from detail
		public int ramenID { get; set; }
		public int Quantity { get; set; }

		// from ramen
		public int meatID { get; set; } // fk
		public string ramenName { get; set; }
		public string Broth { get; set; }
		public string Price { get; set; }

		// from meat
		public string meatName { get; set; }

	}
}