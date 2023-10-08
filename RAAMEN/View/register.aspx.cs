using RAAMEN.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View {

	//nb. register only for guest to set as 'Buyer' OR 'Seller' role
	public partial class register : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

        protected void regisBtn_Click(object sender, EventArgs e) {

			string username = userIn.Text;
			string email = emailIn.Text;
			string gender = radioGender.SelectedValue;
			string password = passIn.Text;
			string passConfirm = passInConfirm.Text;
			string selectedRole = radioRole.SelectedValue;

			switch(regisControl.validateBtn(username, email, gender, password, passConfirm, selectedRole)) { // call controller for validation

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
					errorLbl.Text = "Password Confirmantion cannot be empty";
					break;

				case 7:
					errorLbl.Text = "Password does not match with confirmed password";
					break;

				case 8:
					errorLbl.Text = "Role cannot be empty";
					break;

				case 9:
					errorLbl.Text = "Successfulyl registered";
					break;

				default:
					errorLbl.Text = "Something went wrong";
					break;

			
			}

        }
    }
}