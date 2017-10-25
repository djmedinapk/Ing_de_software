using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_home_Index : System.Web.UI.Page
{
    void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            this.MasterPageFile = "~/Master2_2.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   
}