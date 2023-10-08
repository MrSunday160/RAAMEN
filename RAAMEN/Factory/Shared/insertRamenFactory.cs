using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Factory.Shared {
	public class insertRamenFactory {

		public static RamenDetail newRamen(string name, string broth, string price, int meat) {

			RamenDetail ramenDetail = new RamenDetail();
			ramenDetail.Name = name;
			ramenDetail.meatID = meat;
			ramenDetail.Broth =	broth;
			ramenDetail.Price = price;

			return ramenDetail;

		}

	}
}