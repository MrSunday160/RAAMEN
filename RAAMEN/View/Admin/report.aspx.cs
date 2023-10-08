using CrystalDecisions.CrystalReports.Engine;
using RAAMEN.Repository.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Admin {
	public partial class report : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

			if(Session["user"] == null && Request.Cookies["roleCookie"] == null) {

				Debug.WriteLine("not valid");
				Response.Redirect("~/View/login.aspx");

			}

			else if(!"Admin".Equals(Session["user"]?.ToString()) &&
		 !"Admin".Equals(Request.Cookies["roleCookie"]?.Value)) { // use null-conditional operator to access value safely

				Debug.WriteLine("wrong role");

				// reset cookie and session
				HttpCookie cookie = new HttpCookie("roleCookie");
				cookie.Expires = DateTime.Now.AddDays(-1);
				Response.Cookies.Add(cookie);
				Session["user"] = null;

				HttpCookie userIdCookie = new HttpCookie("userIdCookie");
				userIdCookie.Expires = DateTime.Now.AddDays(-1);
				Response.Cookies.Add(userIdCookie);
				Session["userId"] = null;

				Response.Redirect("~/View/login.aspx");

			}

			// call repository to connect to db
			localDBEntities db = reportRepository.getDB();

			crystalReport cr = new crystalReport();

			List<Header> headers = db.Headers.ToList();
			List<User> users = db.Users.ToList();
			List<Detail> details = db.Details.ToList();
			List<RamenDetail> ramens = db.RamenDetails.ToList();

			dataSet ds = createDataset(headers, details, users, ramens);

			decimal grandTotal = reportRepository.calculateTotal();
			Debug.WriteLine(grandTotal);

			TextObject textField = cr.ReportDefinition.ReportObjects["textField"] as TextObject; // access textField text object from crystal report

			textField.Text = "Grand Total = " + grandTotal.ToString(); // set grand total

			cr.SetDataSource(ds);
			CrystalReportViewer.ReportSource = cr;

		}

		private dataSet createDataset(List<Header> headers, List<Detail> details, List<User> users, List<RamenDetail> ramenDetails) {

			dataSet ds = new dataSet();

			var header = ds.Header;
			var detail = ds.Detail;

			var user = ds.User;
			user.PrimaryKey = new DataColumn[] { user.Columns["ID"] }; // set so that ID is seen as primary key, dont know why

			var ramen = ds.Ramen;

			foreach(User u in users) {

				var urow = user.NewRow();
				urow["ID"] = u.ID;
				urow["roleID"] = u.roleID;
				urow["Username"] = u.Username;
				urow["Email"] = u.Email;
				urow["Gender"] = u.Gender;
				urow["Password"] = u.Password;

				user.Rows.Add(urow);

			}

			foreach(Header th in headers) {

				var hrow = header.NewRow();
				hrow["ID"] = th.ID;
				hrow["customerID"] = th.customerID;
				hrow["staffID"] = th.staffID;
				hrow["Date"] = th.Date;

				header.Rows.Add(hrow);

				var detailList = details.Where(td => td.headerID == th.ID).ToList();
				// logic should be correct, but donno, not running properly
				foreach(Detail td in detailList) {

					var drow = detail.NewRow();
					drow["headerID"] = td.headerID;
					drow["ramenID"] = td.ramenID;
					drow["Quantity"] = td.Quantity;

					detail.Rows.Add(drow);

					var rd = ramenDetails.FirstOrDefault(r => r.ID == td.ramenID);
					if(rd != null) {
						var rrow = ramen.NewRow();
						rrow["ID"] = rd.ID;
						rrow["meatID"] = rd.meatID;
						rrow["Name"] = rd.Name;
						rrow["Broth"] = rd.Broth;
						rrow["Price"] = rd.Price;

						ramen.Rows.Add(rrow);

					}

				}

			}

			return ds;

		}


	}
}