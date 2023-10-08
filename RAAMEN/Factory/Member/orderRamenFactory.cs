using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Factory.Member {
	public class orderRamenFactory {

		public static Header newHeader(int userId) {
		
			Header newHeader = new Header();
			newHeader.customerID = userId;
			newHeader.staffID = null;
			newHeader.Date = DateTime.Now;

			return newHeader;
		
		}

		public static Detail newDetail(int headerId, int qty, int ramenId) {
		
			Detail newDetail = new Detail();
			newDetail.headerID = headerId;
			newDetail.ramenID = ramenId;
			newDetail.Quantity = qty;

			return newDetail;
		
		}

		public static Cart newCart(int headerId) {
		
			Cart newCart = new Cart();
			newCart.headerID = headerId;
			newCart.orderStatus = "Ongoing";

			return newCart;
		
		}

	}
}