﻿using RAAMEN.Controller.Shared;
using RAAMEN.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Staff {
	public partial class updateRamen : System.Web.UI.Page {
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

			int id = int.Parse(Request.QueryString["id"]);

			// call repository to get data by id
			if(!IsPostBack) {

				gvDataById.DataSource = updateRamenRepository.getById(id);
				gvDataById.DataBind();

			}

		}

        protected void backBtn_Click(object sender, EventArgs e) {

			Response.Redirect("manageRamen.aspx");

        }

		protected void updateBtn_Click(object sender, EventArgs e) {

			string name = nameIn.Text;
			string meat = radioMeat.SelectedValue;
			string broth = brothIn.Text;
			string price = priceIn.Text;

			int id = int.Parse(Request.QueryString["id"]);

			// call controller, can use insert controller because same parameters

			switch(updateRamenControl.validateBtn(name, meat, broth, price, id)) {

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
					errorLbl.Text = "Update Successful";
					break;

			}

		}
	}
}