using RAAMEN.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Shared {
	public class orderDetailRepository {

		public static localDBEntities db = new localDBEntities();

		public static List<headerDetailCartViewModel> getDetailById(int id) {

			return (from x in db.Headers
					join y in db.Details on x.ID equals y.headerID
					join z in db.Carts on x.ID equals z.headerID
					where x.ID == id
					select new headerDetailCartViewModel {

						headerID = y.headerID,
						customerID = x.customerID,
						staffID = x.staffID,
						Date = x.Date,

						ramenID = y.ramenID,
						Quantity = y.Quantity,

						orderStatus = z.orderStatus

					}).ToList();

			// similar with insertRamenRepository, using viewmodel for the gridview

		}

	}
}