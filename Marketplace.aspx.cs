using AgriEnergy.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgriEnergy
{
    public partial class Marketplace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHelper.CheckUserSession(Session, Response);
        }
    }
}