using RAAMEN.Handler.Member;
using RAAMEN.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository.Member {
	public class orderRamenRepository {

		public static localDBEntities db = new localDBEntities();

		public static List<RamenDetail> getAllRamenDetails() {

			//Debug.WriteLine("get all data");
			return db.RamenDetails.ToList();

		}

		public static void addRamen(List<cartViewModel> cart, int userId) {

			// extract each values, then call handler
			// first, add into header so that we can hold the headerID
			// call handler to insert into Header table and storing the most recent id
			int headerId = orderRamenHandler.insertHeader(db, userId);

			// insert new cart using headerID, so that cart is only created once, not repetetive
			orderRamenHandler.insertCart(db, headerId);

			foreach (cartViewModel cartItem in cart) {

				int ramenId = cartItem.ramenID;
				int quantity = cartItem.Quantity;
				
				// call handler to insert into detail and cart table
				orderRamenHandler.insertRamen(db, headerId, quantity, ramenId);

			}

			Debug.WriteLine("add done");

		}

	}
}