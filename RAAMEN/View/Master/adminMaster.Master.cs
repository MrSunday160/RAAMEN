using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Master {
	public partial class adminMaster : System.Web.UI.MasterPage {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void logoutBtn_Click(object sender, EventArgs e) {

			HttpCookie cookie = new HttpCookie("roleCookie");
			cookie.Expires = DateTime.Now.AddDays(-1);
			Response.Cookies.Add(cookie);
			Session["user"] = null;

			HttpCookie userIdCookie = new HttpCookie("userIdCookie");
			userIdCookie.Expires = DateTime.Now.AddDays(-1);
			Response.Cookies.Add(userIdCookie);
			Session["userId"] = null;

			//Debug.WriteLine(cookie.Value);

			Response.Redirect("~/View/login.aspx");
		}

	}
}