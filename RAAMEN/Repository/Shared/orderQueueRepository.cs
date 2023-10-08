using RAAMEN.Handler.Shared;
using RAAMEN.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Shared {
	public class orderQueueRepository {

		public static localDBEntities db = new localDBEntities();

		public static List<headerDetailCartViewModel> getData() {

			return (from x in db.Headers join y in db.Details on x.ID equals y.headerID join z in db.Carts on x.ID equals z.headerID select new headerDetailCartViewModel {

				ID = x.ID,
				customerID = x.customerID,
				staffID = x.staffID,
				Date = x.Date,

				headerID = y.headerID,
				ramenID = y.ramenID,
				Quantity = y.Quantity,

				orderStatus = z.orderStatus

			}).ToList();

			// similar with insertRamenRepository and orderDetailRepository for the gridview datasource

		}

		public static string getById(int id, string status) {

			Cart temp = (from x in db.Carts where x.headerID == id select x).FirstOrDefault();

			if (temp != null) { // data found

				// call handler to update

				if(status.Equals("Done"))
					orderQueueHandler.changeStatus("Done", db, temp);

				else
					orderQueueHandler.changeStatus("Ongoing", db, temp);

				Debug.WriteLine("update done");
				return "Update Successful";

			}

			else {

				Debug.WriteLine("not found");
				return "Transaction not found";

			}

		}

	}
}