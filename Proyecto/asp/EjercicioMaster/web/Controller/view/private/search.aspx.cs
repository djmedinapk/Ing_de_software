using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_Private_search : System.Web.UI.Page
{
    String busqueda;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                busqueda = Request.QueryString["search"].ToString();
                Tsearch.Text = busqueda;
            }
            catch
            {
                busqueda = "";
            }
        }

    }
}