using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Admin {
	public class reportRepository {

		public static localDBEntities db = new localDBEntities();

		public static localDBEntities getDB() {

			return db;

		}

		public static decimal calculateTotal() {

			var headers = db.Headers.ToList();
			decimal grandTotal = 0;

			foreach(var header in headers) {

				var details = header.Details;
				
				foreach(var detail in details) {

					var price = (from x in db.RamenDetails where x.ID == detail.ramenID select x.Price).FirstOrDefault();
					// still in string

					grandTotal += detail.Quantity * Convert.ToDecimal(price);

				}

			}

			return grandTotal;

		}

	}
}