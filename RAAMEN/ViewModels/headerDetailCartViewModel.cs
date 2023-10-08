using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.ViewModels {
	public class headerDetailCartViewModel {

		// from Header
		public int ID { get; set; }
		public int customerID { get; set; }
		public Nullable<int> staffID { get; set; }
		public System.DateTime Date { get; set; }

		// from Detail
		public int headerID { get; set; }
		public int ramenID { get; set; }
		public int Quantity { get; set; }
		public virtual Header Header { get; set; }
		public virtual RamenDetail RamenDetail { get; set; }

		//cart's headerID not necessary because already exist from Detail
		public string orderStatus { get; set; }

	}
}