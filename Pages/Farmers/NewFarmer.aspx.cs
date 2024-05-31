using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using AgriEnergy.Controller;
using AgriEnergy.Classes;

namespace AgriEnergy.Pages.Farmers
{
    //----------------------------//
    // START OF CLASS
    //----------------------------//
    public partial class NewFarmer : System.Web.UI.Page
    {
        //---------------------------------//
        // PAGE LOAD METHOD
        //---------------------------------//
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHelper.CheckUserSession(Session, Response);
        }
        //---------------------------------//
        // SUBMIT BUTTON CLICK METHOD
        //---------------------------------//
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Check if the passwords match
            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                ErrorMessageLabel.Text = "The passwords do not match.";
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Create an instance of the Validation class
            Validation validator = new Validation();

            // Validate the farmer input
            bool isInputValid = validator.ValidateRegistrationInput2(
                FirstNameTextBox.Text,
                LastNameTextBox.Text,
                MobileNumberTextBox.Text,
                EmailTextBox.Text,
                UsernameTextBox.Text,
                PasswordTextBox.Text,
                ConfirmPasswordTextBox.Text,
                LocationTextBox.Text);

            if (!isInputValid)
            {
                // Farmer input is not valid, display an error message and return early
                ErrorMessageLabel.Text = validator.ErrorMessage;
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Check if the username exists
            if (!DBHelper.IsUsernameAvailable(UsernameTextBox.Text))
            {
                // Username is not available, display an error message and return early
                ErrorMessageLabel.Text = "The username is already taken.";
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Check if the email address exists
            if (!DBHelper.IsEmailAvailable(EmailTextBox.Text))
            {
                // Email address is not available, display an error message and return early
                ErrorMessageLabel.Text = "The email address is already in use.";
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Insert the new farmer into the Farmers and Users tables
            using (SqlConnection connection = new SqlConnection(DBHelper.ConnectionString))
            {
                connection.Open();

                // Insert into Users table
                using (SqlCommand command = new SqlCommand("INSERT INTO Users (FullName, MobileNumber, Email, Username, Password, Role) VALUES (@FullName, @MobileNumber, @Email, @Username, @Password, 'Farmer')", connection))
                {
                    command.Parameters.AddWithValue("@FullName", FirstNameTextBox.Text + " " + LastNameTextBox.Text);
                    command.Parameters.AddWithValue("@MobileNumber", MobileNumberTextBox.Text);
                    command.Parameters.AddWithValue("@Email", EmailTextBox.Text);
                    command.Parameters.AddWithValue("@Username", UsernameTextBox.Text);
                    command.Parameters.AddWithValue("@Password", PasswordTextBox.Text);

                    command.ExecuteNonQuery();
                }

                // Get the UserID of the new user
                int userID;
                using (SqlCommand command = new SqlCommand("SELECT UserID FROM Users WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", UsernameTextBox.Text);

                    userID = (int)command.ExecuteScalar();
                }

                // Insert into Farmers table
                using (SqlCommand command = new SqlCommand("INSERT INTO Farmers (FirstName, LastName, Location, MobileNumber, EmployeeID) VALUES (@FirstName, @LastName, @Location, @MobileNumber, @EmployeeID)", connection))
                {
                    command.Parameters.AddWithValue("@FirstName", FirstNameTextBox.Text);
                    command.Parameters.AddWithValue("@LastName", LastNameTextBox.Text);
                    command.Parameters.AddWithValue("@Location", LocationTextBox.Text);
                    command.Parameters.AddWithValue("@MobileNumber", MobileNumberTextBox.Text);
                    command.Parameters.AddWithValue("@EmployeeID", Session["UserID"]);

                    command.ExecuteNonQuery();
                }
            }
            // Redirect to the Farmers page
            Response.Redirect("Farmers.aspx");
        }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//