using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Data;

public partial class view_home_Index : System.Web.UI.Page
{
    void Page_PreInit(Object sender, EventArgs e)
    {

        Lotros master = new Lotros();
        try
        {
            this.MasterPageFile = master.aux2((DataRow)Session["data_user"]);
        }
        catch { }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   
}