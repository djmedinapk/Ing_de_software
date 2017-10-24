using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Blogout_Click(object sender, EventArgs e)
    {
        Session["user_id"] = null;
        Session["username"] = null;

        DAOUsuario user = new DAOUsuario();
        Eusuario datos = new Eusuario
        {
            Session = Session.SessionID
        };
        user.CerrarSession(datos);

        Response.Redirect("../login/ingresar.aspx");
    }
}