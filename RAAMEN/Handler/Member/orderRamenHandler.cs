using RAAMEN.Factory.Member;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace RAAMEN.Handler.Member {
	public class orderRamenHandler {

		public static int insertHeader(localDBEntities db, int userId) {

			// call factory
			Header addHeader = orderRamenFactory.newHeader(userId);

			db.Headers.Add(addHeader);
			db.SaveChanges();

			Debug.WriteLine("added into header");
			Debug.WriteLine(addHeader.ID);

			return addHeader.ID;

		}
		public static void insertCart(localDBEntities db, int headerId) {

			Cart addCart = orderRamenFactory.newCart(headerId);
			db.Carts.Add(addCart);
			db.SaveChanges();

		}

		public static void insertRamen(localDBEntities db, int headerId, int quantity, int ramenId) {

			// call factory
			Detail addDetail = orderRamenFactory.newDetail(headerId, quantity, ramenId);
			
			db.Details.Add(addDetail);
			
			// mainly for debugging
			try {
				// Code to add and save the new entry
				db.SaveChanges();
			}
			catch(DbUpdateException ex) {
				Exception innerException = ex.InnerException;
				string errorMessage = innerException.Message;
				// Handle or log the error message as needed
				Debug.WriteLine(errorMessage);
			}


			Debug.WriteLine("add done w/ value: headerId, qty, ramenId: " + headerId, quantity, ramenId);

		}
	}
}