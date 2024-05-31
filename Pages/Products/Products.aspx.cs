using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using AgriEnergy.Controller;

namespace AgriEnergy.Pages.Products
{
    //----------------------------//
    // START OF CLASS
    //----------------------------//
    public partial class Products : System.Web.UI.Page
    {
        //---------------------------------//
        // PAGE LOAD METHOD
        //---------------------------------//
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHelper.CheckUserSession(Session, Response);

            if (Session["Role"].ToString() == "Employee")
            {
                // Show the "Add New Product" button, category search box,
                // "Search" button, and farmer username search for employees
                btn_AddNewProduct.Visible = false;
                CategoryLabel.Visible = true;
                CategorySearchTextBox.Visible = true;
                CategorySearchButton.Visible = true;
                FarmerUsernameLabel.Visible = true;
                FarmerSearchTextBox.Visible = true;
                FarmerSearchButton.Visible = true;
            }
            else
            {
                // Hide the farmer username and category search for non-employees
                FarmerUsernameLabel.Visible = false;
                CategoryLabel.Visible = false;
                FarmerSearchTextBox.Visible = false;
                FarmerSearchButton.Visible = false;
            }

            if (!IsPostBack)
            {
                if (Session["Role"].ToString() == "Employee")
                {
                    // If the user is an employee, select all products
                    ProductsTab.SelectCommand = "SELECT * FROM [Products]";
                }
                else
                {
                    // If the user is a farmer, select only their products
                    ProductsTab.SelectCommand = "SELECT * FROM [Products] WHERE FarmerID = @FarmerID";
                    ProductsTab.SelectParameters.Add("FarmerID", Session["UserID"].ToString());
                }

                // Bind the data to the GridView
                GridView1.DataBind();
            }
        }
        //---------------------------------//
        // ROW DELETING BUTTON METHOD
        //---------------------------------//
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the ProductID of the product being deleted
            int productID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            // Create a connection to the database
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                // Create a command to delete the product
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @ProductID", conn))
                {
                    // Add the ProductID parameter to the command
                    cmd.Parameters.AddWithValue("@ProductID", productID);

                    // Open the connection
                    conn.Open();

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Close the connection
                    conn.Close();
                }
            }

            // Refresh the GridView
            GridView1.DataBind();
        }
        //---------------------------------//
        // FILTER BUTTON METHOD
        //---------------------------------//
        protected void FilterButton_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            if (!DateTime.TryParse(StartDateTextBox.Text, out startDate))
            {
                // Invalid start date format
                return;
            }

            DateTime endDate;
            if (!DateTime.TryParse(EndDateTextBox.Text, out endDate))
            {
                // Invalid end date format
                return;
            }

            // Modify the SelectCommand to filter the products by the production date
            ProductsTab.SelectCommand = "SELECT * FROM [Products] WHERE FarmerID = @FarmerID AND ProductionDate BETWEEN @StartDate AND @EndDate";
            ProductsTab.SelectParameters.Clear();
            ProductsTab.SelectParameters.Add("FarmerID", Session["UserID"].ToString());
            ProductsTab.SelectParameters.Add("StartDate", startDate.ToString("yyyy-MM-dd"));
            ProductsTab.SelectParameters.Add("EndDate", endDate.ToString("yyyy-MM-dd"));

            // Bind the data to the GridView
            GridView1.DataBind();
        }
        //---------------------------------//
        // RESET BUTTON METHOD
        //---------------------------------//
        protected void ResetButton_Click(object sender, EventArgs e)
        {
            // Clear the date filters
            CategorySearchTextBox.Text = string.Empty;
            StartDateTextBox.Text = string.Empty;
            EndDateTextBox.Text = string.Empty;

            // Reset the SelectCommand to display all the products
            if (Session["Role"].ToString() == "Employee")
            {
                // If the user is an employee, select all products
                ProductsTab.SelectCommand = "SELECT * FROM [Products]";
                ProductsTab.SelectParameters.Clear();
            }
            else
            {
                // If the user is a farmer, select only their products
                ProductsTab.SelectCommand = "SELECT * FROM [Products] WHERE FarmerID = @FarmerID";
                ProductsTab.SelectParameters.Clear();
                ProductsTab.SelectParameters.Add("FarmerID", Session["UserID"].ToString());
            }

            // Bind the data to the GridView
            GridView1.DataBind();
        }
        //---------------------------------//
        // CATEGORY SEARCH BUTTON METHOD
        //---------------------------------//
        protected void CategorySearchButton_Click(object sender, EventArgs e)
        {
            // Get the category from the search box
            string category = CategorySearchTextBox.Text;

            // Modify the SelectCommand to filter the products by the category
            ProductsTab.SelectCommand = "SELECT * FROM [Products] WHERE Category LIKE @Category";
            ProductsTab.SelectParameters.Clear();
            ProductsTab.SelectParameters.Add("Category", "%" + category + "%");

            // Bind the data to the GridView
            GridView1.DataBind();
        }
        //---------------------------------//
        // FARMER SEARCH BUTTON METHOD
        //---------------------------------//
        protected void FarmerSearchButton_Click(object sender, EventArgs e)
        {
            // Get the username from the search box
            string username = FarmerSearchTextBox.Text;

            // Modify the SelectCommand to filter the products by the farmer's username
            ProductsTab.SelectCommand = "SELECT Products.* FROM Products JOIN Farmers ON Products.FarmerID = Farmers.FarmerID JOIN Users ON Farmers.FarmerID = Users.UserID WHERE Users.Username = @Username";
            ProductsTab.SelectParameters.Clear();
            ProductsTab.SelectParameters.Add("Username", username);

            // Bind the data to the GridView
            GridView1.DataBind();
        }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//