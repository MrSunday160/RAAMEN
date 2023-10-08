using RAAMEN.Controller.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Admin {
	public partial class insertRamen : System.Web.UI.Page {
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

		}

		protected void backBtn_Click(object sender, EventArgs e) {

			Response.Redirect("manageRamen.aspx");

		}

		protected void insertBtn_Click(object sender, EventArgs e) {

			string name = nameIn.Text;
			string meat = radioMeat.SelectedValue;
			string broth = brothIn.Text;
			string price = priceIn.Text;

			// call controller
			switch(insertRamenControl.validateBtn(name, meat, broth, price)) {

				case 1:
					errorLbl.Text = "All fields cannot be empty";
					break;

				case 2:
					errorLbl.Text = "Name must contain Ramen";
					break;

				case 3:
					errorLbl.Text = "Broth cannot be emtpy";
					break;

				case 4:
					errorLbl.Text = "Price must be over 3000";
					break;

				case 5:
					errorLbl.Text = "Invalide price format";
					Debug.WriteLine("parse into int fail");
					break;

				case 6:
					errorLbl.Text = "Insert Successful";
					break;

			}

		}

	}
}