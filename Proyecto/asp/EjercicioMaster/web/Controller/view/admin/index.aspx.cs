using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_admin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DAOadmin admin = new DAOadmin();
        DataTable datos = admin.cargar_pag_home();
        if (datos.Rows.Count > 0)
        {
            LtotalUsers.Text = datos.Rows[0]["_totaluser"].ToString();
            HLtotalUser.Attributes.Add("data-content","Usuarios Activos: "+ datos.Rows[0]["_totaluser_activos"].ToString()+ "<br>Usuarios suspendido: " + datos.Rows[0]["_totaluser_suspendidos"].ToString()+ "<br>Usuarios inactivos: " + datos.Rows[0]["_totaluser_inactivos"].ToString());
            LtotalPost.Text = datos.Rows[0]["_totalPost"].ToString();
            HLtotalPost.Attributes.Add("data-content", "Publicaciones Activas: " + datos.Rows[0]["_totalPost_activos"].ToString() + "<br>Publicaciones suspendidas: " + datos.Rows[0]["_totalPost_suspendidos"].ToString() + "<br>Publicaciones Pendientes: " + datos.Rows[0]["_totalPost_pendientes"].ToString());
            LtotalComentarios.Text = datos.Rows[0]["_totalcomentarios"].ToString();
            LtotalPuntos.Text = datos.Rows[0]["_totalpoints"].ToString();
        }
    }
}