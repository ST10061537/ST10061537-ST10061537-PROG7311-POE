using AgriEnergy.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgriEnergy
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHelper.CheckUserSession(Session, Response);

            if (Session["Username"] != null)
            {
                string role = Session["Role"].ToString();
                string fullName = Session["FullName"].ToString();

                WelcomeMessage.Text = $"Welcome {role}, {fullName}";
            }
        }
    }
}