using RAAMEN.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Staff {
	public partial class orderQueue : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

			if(Session["user"] == null && Request.Cookies["roleCookie"] == null) {

				Debug.WriteLine("not valid");
				Response.Redirect("~/View/login.aspx");

			}

			else if(!"Staff".Equals(Session["user"]?.ToString()) &&
		 !"Staff".Equals(Request.Cookies["roleCookie"]?.Value)) { // use null-conditional operator to access value safely

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

				gvOrders.DataSource = orderQueueRepository.getData();
				gvOrders.DataBind();

			}

		}

		protected void updateBtn_Click(object sender, EventArgs e) {

			int id = int.Parse(idIn.Text);
			string status = radioOrderStatus.SelectedValue;

			// call repository to check for the given Id
			errorLbl.Text = orderQueueRepository.getById(id, status);

		}
	}
}