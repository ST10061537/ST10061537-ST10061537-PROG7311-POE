using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AgriEnergy.Controller
{
    //----------------------------//
    // START OF CLASS
    //----------------------------//
    public class DBHelper
    {
        public static string ConnectionString { get; } = "Server=tcp:dbs-prog7311-st10061537.database.windows.net,1433;Initial Catalog=db-prog7311-st10061537;Persist Security Info=False;User ID=ST10061537;Password=Familyguy101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //---------------------------------//
        // CHECK USER SESSION METHOD
        //---------------------------------//
        public static void CheckUserSession(System.Web.SessionState.HttpSessionState session, System.Web.HttpResponse response)
        {
            // Check if the user is logged in
            if (session["UserID"] == null)
            {
                // The user isn't logged in, redirect them to the login page
                response.Redirect("~/Pages/Login/Login.aspx");
            }
        }
        //---------------------------------//
        // CHECK IF USERNAME IS AVAILABLE
        //---------------------------------//
        public static bool IsUsernameAvailable(string username)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    int count = (int)command.ExecuteScalar();

                    return count == 0;
                }
            }
        }
        //---------------------------------//
        // CHECK IF EMAIL IS AVAILABLE
        //---------------------------------//
        public static bool IsEmailAvailable(string email)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    int count = (int)command.ExecuteScalar();

                    return count == 0;
                }
            }
        }
        //---------------------------------//
        // GET USERNAME AND FULL NAME 
        //---------------------------------//
        public static void GetUserDetails(string username, System.Web.SessionState.HttpSessionState session)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fullName = reader["FullName"].ToString();
                            string role = reader["Role"].ToString();

                            // Store the full name and role in the Session object
                            session["FullName"] = fullName;
                            session["Role"] = role;
                        }
                    }
                }
            }
        }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//