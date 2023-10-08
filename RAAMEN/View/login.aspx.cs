using RAAMEN.Controller;
using RAAMEN.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View {
	public partial class login : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

        protected void loginBtn_Click(object sender, EventArgs e) {

			string username = userIn.Text;
			string password = passIn.Text;
			bool rememberMe = rememberRadio.Checked;

			// call controller to validate input
			// hold on error msg
			string errorTemp = loginControl.validateBtn(username, password);

			if(string.IsNullOrEmpty(errorTemp) ) { // authentication successful

				Debug.WriteLine("Authentication succesfull");

				// get roles from repository
				string roleTemp = loginRepository.getRoles(username);

				Session["user"] = roleTemp; // hold roleTemp in session
				//Debug.WriteLine(Session["user"], "Session['user']");

				// get userId from username given and save to Session[]
				int userId = loginRepository.getId(username);
				Session["userId"] = userId;

				//Debug.WriteLine("string isnullorempty OK", roleTemp);
				//Debug.WriteLine("userId: " + userId);

				// if rememberMe selected, set cookies
				if(rememberMe) {

					Debug.WriteLine("rememberMe checked");

					HttpCookie cookie = new HttpCookie("roleCookie");
					cookie.Value = roleTemp;
					cookie.Expires = DateTime.Now.AddHours(2); // set expiry
					Response.Cookies.Add(cookie);

					HttpCookie userIdCookie = new HttpCookie("userIdCookie");
					userIdCookie.Value = userId.ToString();
					userIdCookie.Expires = DateTime.Now.AddHours(2);
					Response.Cookies.Add(userIdCookie);

					Debug.WriteLine("roleCookie value" + Request.Cookies["roleCookie"].Value);
					Debug.WriteLine("userIdCookie value" + Request.Cookies["userIdCookie"].Value);

				}

				// redirect for each roles
				if(roleTemp.Equals("Staff")) {

					Debug.WriteLine("staff found");
					Response.Redirect("~/View/Staff/staffHome.aspx");

				}

				else if(roleTemp.Equals("Member")) {

					Debug.WriteLine("member found");
					Response.Redirect("~/View/Member/memberHome.aspx");
					
				}
					

				else if(roleTemp.Equals("Admin")) {

					Debug.WriteLine("admin found");
					Response.Redirect("~/View/Admin/adminHome.aspx");
					
				}

				else {

					Debug.WriteLine("default/else/error");
					Response.Redirect("login.aspx");
					
				}	

			}

			else
				errorLbl.Text = errorTemp; // validation error, display error label

		}
    }
}