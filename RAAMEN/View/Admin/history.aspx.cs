using RAAMEN.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Admin {
	public partial class history : System.Web.UI.Page {
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

			if(!IsPostBack) {

				gvHeader.DataSource = historyRepository.getAllDone();
				gvHeader.DataBind();

			}

		}

        protected void viewDetailBtn_Click(object sender, EventArgs e) {

			Button viewDetailBtn = (Button)sender; // hold viewDetailButton by casting sender object to Button type
												   // in this case, holds the button when pressed as an object, allowing access to Button's properties

			string id = viewDetailBtn.CommandArgument; // holds the CommandArgument property of the button.
			// uses <%# Eval("ID") %> to get ID value from the row
			// ID value in this case is the 'Header' table ID
			// see gettAllDone() from repository

			Debug.WriteLine(id);

			Response.Redirect("orderDetail.aspx?id=" + id);

		}

	}
}