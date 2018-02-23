using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var papas = (DataRow)Session["data_user"];
        if (papas!=null) {
            if (Session["correo_inst"] != null || papas["id_permisos"].ToString()=="2")
            {
                Lusername.Text = papas["username"].ToString();
            }
            else
            {
                Response.Redirect("~/view/perfil/correoinstitucional.aspx");
            }
        }
        else
        {
            Response.Redirect("~/view/home/index.aspx");
        }
    }

    protected void BTNsearch_Click(object sender, EventArgs e)
    {
        String busqueda = Tsearch.Text;
        Response.Redirect("~/view/private/search.aspx?search=" + busqueda);
    }
}
