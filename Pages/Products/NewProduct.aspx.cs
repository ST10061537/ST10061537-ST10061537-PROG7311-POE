using AgriEnergy.Classes;
using AgriEnergy.Controller;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgriEnergy.Pages.Products
{
    //----------------------------//
    // START OF CLASS
    //----------------------------//
    public partial class NewProduct : System.Web.UI.Page
    {
        //---------------------------------//
        // PAGE LOAD METHOD
        //---------------------------------//
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHelper.CheckUserSession(Session, Response);
        }
        //---------------------------------//
        // BTN SUMBIT METHOD
        //---------------------------------//
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string category = CategoryTextBox.Text;
            DateTime productionDate;
            if (!DateTime.TryParse(ProductionDateTextBox.Text, out productionDate))
            {
                ErrorMessageLabel.Text = "Invalid date format.";
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            string description = DescriptionTextBox.Text;

            // Create an instance of the Validation class
            Validation validator = new Validation();

            // Validate the product input
            bool isInputValid = validator.ValidateProductInput(name, category, productionDate.ToString(), description);

            if (!isInputValid)
            {
                // Product input is not valid, display an error message and return early
                ErrorMessageLabel.Text = validator.ErrorMessage;
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Get the ID of the currently logged-in farmer from the session variable
            int farmerID = int.Parse(Session["UserID"].ToString());

            using (SqlConnection connection = new SqlConnection(DBHelper.ConnectionString))
            {
                string query = "INSERT INTO Products (Name, Category, ProductionDate, Description, FarmerID) VALUES (@Name, @Category, @ProductionDate, @Description, @FarmerID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@ProductionDate", productionDate);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@FarmerID", farmerID);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Response.Redirect("Products.aspx");
                    }
                    else
                    {
                        ErrorMessageLabel.Text = "Error adding product.";
                        ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//