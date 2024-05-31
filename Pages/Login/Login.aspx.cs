using AgriEnergy.Controller;
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace AgriEnergy.Pages.Login
{
    //----------------------------//
    // START OF CLASS
    //----------------------------//
    public partial class Login : Page
    {
        //---------------------------------//
        // PAGE LOAD METHOD
        //---------------------------------//
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //---------------------------------//
        // BTN LOGIN CLICK METHOD
        //---------------------------------//
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            // Get the input values from the textboxes
            string username = txt_Username.Text;
            string password = txt_password.Text;

            // Validate the input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                // Display an error message
                ErrorMessageLabel.Text = "Please enter both your username and password.";
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // Check if the username and password match the registration details in the database
                using (SqlConnection connection = new SqlConnection(DBHelper.ConnectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Query to select the user with the given username and password
                    string selectQuery = "SELECT UserID, Role, Username, FullName FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        // Add parameters to the SQL command to prevent SQL injection
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the SQL command and get the result
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Login successful, store the user's ID, role, username, and full name in session variables
                                Session["UserID"] = reader["UserID"].ToString();
                                Session["Role"] = reader["Role"].ToString();
                                Session["Username"] = reader["Username"].ToString();
                                Session["FullName"] = reader["FullName"].ToString();

                                // Check the selected user type and redirect to the corresponding page
                                if (rb_Employee.Checked && Session["Role"].ToString() == "Employee")
                                {
                                    Response.Redirect("~/Default.aspx");
                                }
                                else if (rb_Farmer.Checked && Session["Role"].ToString() == "Farmer")
                                {
                                    Response.Redirect("~/Default.aspx");
                                }
                                else
                                {
                                    // The selected user type doesn't match the user's role in the database
                                    ErrorMessageLabel.Text = "Invalid user type.";
                                    ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                // Login failed, display an error message
                                ErrorMessageLabel.Text = "Invalid username or password.";
                                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
            }
        }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//