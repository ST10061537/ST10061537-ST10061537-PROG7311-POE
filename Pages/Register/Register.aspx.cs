using AgriEnergy.Classes;
using AgriEnergy.Controller;
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace AgriEnergy.Pages.Register
{
    //----------------------------//
    // START OF CLASS
    //----------------------------//
    public partial class Register : Page
    {
        //---------------------------------//
        // PAGE LOAD METHOD
        //---------------------------------//
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnString = DBHelper.ConnectionString;
        }
        //---------------------------------//
        // BTN CANCEL METHOD
        //---------------------------------//
        protected void btn_Register_Click(object sender, EventArgs e)
        {
            // Get the input values from the textboxes
            string fullName = txt_name.Text;
            string mobileNumber = txt_mobile.Text;
            string email = txt_email.Text;
            string username = txt_username.Text;
            string password = txt_password.Text;
            string confirmPassword = txt_confirm_password.Text;

            // Creating an instance of the registration validator
            Validation validator = new Validation();

            // Validate the registration input
            bool isInputValid = validator.ValidateRegistrationInput(fullName, mobileNumber, email, username, password, confirmPassword);

            if (isInputValid)
            {
                // Registration input is valid, perform the registration logic

                // Create a connection to the database
                using (SqlConnection connection = new SqlConnection(DBHelper.ConnectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Query to insert the user input into the "Users" table
                    string insertQuery = "INSERT INTO Users (FullName, MobileNumber, Email, Username, Password) VALUES (@FullName, @MobileNumber, @Email, @Username, @Password)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SQL command to prevent SQL injection
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the SQL command
                        command.ExecuteNonQuery();
                    }
                }
                // Redirect to a success page or perform any other actions
                Server.Transfer("~/Pages/Login/Login.aspx");
            }
            else
            {
                // Registration input is not valid, display an error message or take appropriate action
                ErrorMessageLabel.Text = "Please fill in all the required fields.";
            }
        }
        //---------------------------------//
        // BTN CANCEL METHOD
        //---------------------------------//
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Login/Login.aspx");
        }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//