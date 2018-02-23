using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_search : System.Web.UI.Page
{
    String busqueda;
    void Page_PreInit(Object sender, EventArgs e)
    {

        if (Session["username"] != null)
        {
            this.MasterPageFile = "~/Master2_2.master";
        }
    }
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