using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class view_Private_search : System.Web.UI.Page
{
    String busqueda;
    protected void Page_Load(object sender, EventArgs e)
    {
        Lotros aux = new Lotros();
        Int32 aux1;
        try {
            aux1 = Int32.Parse(aux.aux1(IsPostBack));
            busqueda = Request.QueryString["search"].ToString();
            Tsearch.Text = busqueda;
        } catch { busqueda = ""; }
        

    }
}