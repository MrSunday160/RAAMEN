using RAAMEN.Controller.Staff;
using RAAMEN.Repository.Staff;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Member {
	public partial class profile : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

			if(Session["user"] == null && Request.Cookies["roleCookie"] == null) {

				Debug.WriteLine("not valid");
				Response.Redirect("~/View/login.aspx");

			}

			else if(!"Member".Equals(Session["user"]?.ToString()) &&
		 !"Member".Equals(Request.Cookies["roleCookie"]?.Value)) { // use null-conditional operator to access value safely

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

			int userId = getUserId();

			if(!IsPostBack) {

				gvProfile.DataSource = profileRepository.getUser(userId);
				gvProfile.DataBind();

			}

		}

		protected int getUserId() {

			if(Request.Cookies["userIdCookie"] == null)  // cookie not set (remember me not selected)
				return (int)Session["userId"];

			else // remember me selected
				return int.Parse(Request.Cookies["userIdCookie"].Value);

		}

		protected void updateBtn_Click(object sender, EventArgs e) {

			string username = userIn.Text;
			string email = emailIn.Text;
			string gender = radioGender.SelectedValue;

			string passConfirm = passConfIn.Text;

			int userId = getUserId();

			// call controller
			switch(profileControl.validateBtn(username, email, gender, passConfirm, userId)) {

				case 0:
					errorLbl.Text = "Username cannot be empty";
					break;

				case 1:
					errorLbl.Text = "Username must be between 5 and 15 characters with only alphabets";
					break;

				case 2:
					errorLbl.Text = "Email cannot be empty";
					break;

				case 3:
					errorLbl.Text = "Email must end with .com";
					break;

				case 4:
					errorLbl.Text = "Gender cannot be empty";
					break;

				case 5:
					errorLbl.Text = "Password cannot be empty";
					break;

				case 6:
					errorLbl.Text = "Password does not match with current profile";
					break;

				case 7:
					errorLbl.Text = "Successfully updated";
					break;

				case 8:
					errorLbl.Text = "Something went wrong";
					break;

				default:
					errorLbl.Text = "Something went wrong";
					break;

			}

		}

	}
}