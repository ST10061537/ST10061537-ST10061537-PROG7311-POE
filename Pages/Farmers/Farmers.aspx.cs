using AgriEnergy.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgriEnergy.Pages.Farmers
{
    //----------------------------//
    // START OF CLASS
    //----------------------------//
    public partial class Farmers : System.Web.UI.Page
    {
        //---------------------------------//
        // PAGE LOAD METHOD
        //---------------------------------//
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHelper.CheckUserSession(Session, Response);

            // Check if the user is a farmer
            if (Session["Role"].ToString() == "Farmer")
            {
                // Hide the "Add New Farmer" button
                btn_AddNewFarmer.Visible = false;
            }
        }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//