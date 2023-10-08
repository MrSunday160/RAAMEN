using RAAMEN.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Staff {
	public partial class manageRamen : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

			//Debug.WriteLine(Session["userRole"]);
			//Debug.WriteLine(Request.Cookies["roleCookie"].Value);

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

			//Debug.WriteLine("masuk else");
			if(!IsPostBack) {

				gvAllRamen.DataSource = manageRamenRepository.getAllRamenDetails();
				gvAllRamen.DataBind();

			}

		}

        protected void updateBtn_Click(object sender, EventArgs e) {

			string updateId = updateIn.Text;
			Debug.WriteLine(updateId);
			Response.Redirect("updateRamen.aspx?id=" + updateId);

        }

		protected void insertBtn_Click(object sender, EventArgs e) {

			Response.Redirect("insertRamen.aspx");

		}

		protected void deleteBtn_Click(object sender, EventArgs e) {

			string deleteId = deleteIn.Text;
			// call repository to check if ramen id is there
			RamenDetail ramenTemp = manageRamenRepository.getById(int.Parse(deleteId));

			if(ramenTemp == null)
				errorLbl.Text = "Ramen ID not found";

			else {

				// call repository to delete ramen with ramenId
				errorLbl.Text = manageRamenRepository.deleteById(ramenTemp);

			}
			
		}
	}
}