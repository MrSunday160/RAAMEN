using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Handler.Shared {
	public class orderQueueHandler {

		public static void changeStatus(string status, localDBEntities db, Cart cart) {

			// change order status here
			cart.orderStatus = status;
			db.SaveChanges();

		}

	}
}