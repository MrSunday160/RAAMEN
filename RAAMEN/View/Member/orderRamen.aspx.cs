using RAAMEN.Factory.Member;
using RAAMEN.Repository.Member;
using RAAMEN.Repository.Shared;
using RAAMEN.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Member {
	public partial class orderRamen : System.Web.UI.Page {
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

			if(!IsPostBack) {

				gvRamenData.DataSource = orderRamenRepository.getAllRamenDetails();
				gvRamenData.DataBind();

			}

			if(Session["cart"] == null) { // set the order & clear button to be hidden

				orderBtn.Visible = false;
				clearBtn.Visible = false;

			}
				

			else { // else data bind to gridview and show button

				gvCart.DataSource = Session["cart"];
				gvCart.DataBind();

				orderBtn.Visible = true;
				clearBtn.Visible = true;

			}

		}

		protected void addToCartBtn_Click(object sender, EventArgs e) {

			Button addToCartBtn = (Button)sender;
			GridViewRow row = (GridViewRow)addToCartBtn.NamingContainer; // find the row containing the button
			string id = addToCartBtn.CommandArgument; // hold the button command argument value
			string qty = ((TextBox)row.FindControl("qtyIn")).Text; // get textbox value from the row

			//Debug.WriteLine(qty + " qty from row with id: " + id);

			addToCart(id, qty);

			// after add to cart, data bind again
			gvCart.DataSource = Session["cart"];
			gvCart.DataBind();

			// set buttons to be visible after doing logic
			orderBtn.Visible = true;
			clearBtn.Visible = true;

		}

		protected void addToCart(string id, string qtyIn) {

			// use session for cart system, call cartFactory class
			List<cartViewModel> cart = Session["cart"] as List<cartViewModel>;

			// check if cart empty, make new List
			if(cart == null)
				cart = new List<cartViewModel>();

			cart.Add(cartFactory.newItem(id, qtyIn));
			Session["cart"] = cart;

		}

		protected void clearBtn_Click(object sender, EventArgs e) {

			clearCart();

		}

		protected void orderBtn_Click(object sender, EventArgs e) {

			List<cartViewModel> cart = Session["cart"] as List<cartViewModel>;

			// debugging
			if(cart != null && cart.Count > 0) {
				foreach(cartViewModel cartItem in cart) {
					// Output the values of each cart item
					Debug.WriteLine("Ramen ID: " + cartItem.ramenID);
					Debug.WriteLine("Quantity: " + cartItem.Quantity);
					Debug.WriteLine("Meat ID: " + cartItem.meatID);
					Debug.WriteLine("Meat ID: " + cartItem.ramenName);
					Debug.WriteLine("Meat ID: " + cartItem.Broth);
					Debug.WriteLine("Meat ID: " + cartItem.Price);
					// Output other properties as needed
					Debug.WriteLine("------------------");
				}
			}
			else {
				Debug.WriteLine("The cart is empty.");
			}

			int userId = getUserId();

			orderRamenRepository.addRamen(cart, userId);

			clearCart();

			errorLbl.Text = "Successfuly created order";

		}

		// same with profile's getUserId
		protected int getUserId() {

			if(Request.Cookies["userIdCookie"] == null)  // cookie not set (remember me not selected)
				return (int)Session["userId"];

			else // remember me selected
				return int.Parse(Request.Cookies["userIdCookie"].Value);

		}

		protected void clearCart() {

			Session["cart"] = null; // clear cart

			errorLbl.Text = "Cart has been cleared";

			gvCart.DataSource = Session["cart"];
			gvCart.DataBind();

			// set buttons to be invisible
			orderBtn.Visible = false;
			clearBtn.Visible = false;

		}

	}
}