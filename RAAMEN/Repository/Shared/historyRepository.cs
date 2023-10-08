using RAAMEN.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Shared {
	public class historyRepository {

		public static localDBEntities db = new localDBEntities();

		public static List<Header> getAllHeader() {

			return (from x in db.Headers select x).ToList();

		}

		public static List<headerDetailCartViewModel> getAllDone() {

			return (from x in db.Headers
					join y in db.Details on x.ID equals y.headerID
					join z in db.Carts on x.ID equals z.headerID
					where z.orderStatus == "Done"
					select new headerDetailCartViewModel {

						ID = x.ID,
						customerID = x.customerID,
						staffID = x.staffID,
						Date = x.Date,

						orderStatus = z.orderStatus

					}).ToList();

			// in this case, other values of the view model class does not exist, so will still return as null but not used at front end of history page
			// front end only display the values above

		}

		public static List<headerDetailCartViewModel> getById(int id) {

			return (from x in db.Headers
					join y in db.Details on x.ID equals y.headerID
					join z in db.Carts on x.ID equals z.headerID
					where  x.customerID == id
					select new headerDetailCartViewModel {

						ID = x.ID,
						customerID = x.customerID,
						staffID = x.staffID,
						Date = x.Date,

						orderStatus = z.orderStatus

					}).ToList();

		}

	}
}