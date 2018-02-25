using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class view_login_ingresar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["user_id"] == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;

        }
        else
        {
            Response.Redirect("../perfil/perfil.aspx");
        }

    }


    protected void Bregistro_Click(object sender, EventArgs e)
    {
        Uadmin_actualizar_usuario usuario = new Uadmin_actualizar_usuario();
        usuario.Correo = TregistroCorreo.Text;
        usuario.Username = TregistroUser.Text;
        usuario.Session = Session.SessionID;
        usuario.Password = TregistroPassword2.Text;

        Lregistro registro = new Lregistro();
        try
        {
            LMensaje.Text = registro.Bregistro(usuario);
            TloginUser.Text = usuario.Username;
            TloginPassword.Focus();

        }
        catch { }
    }

    protected void Blogin_Click(object sender, EventArgs e)
    {
        Llogin login = new Llogin();
        Uadmin_ver_usuario usuario = new Uadmin_ver_usuario();
        usuario.Username = TloginUser.Text.ToString();
        usuario.Password = TloginPassword.Text.ToString();
        DataTable[] respuesta = login.Blogin(usuario, Session.SessionID);
        try
        {

            LMensaje.Text = respuesta[1].Rows[0]["mensaje"].ToString();

        }
        catch
        {
            // LMensaje.Text = "Algo Ha Salido mal :)";
        }
        try
        {
            Session["username"] = respuesta[0].Rows[0]["username"].ToString();
            Session["user_id"] = respuesta[0].Rows[0]["id"].ToString();
            Session["correo_inst"] = respuesta[1].Rows[0]["correo_ins"].ToString();
            Session["data_user"] = respuesta[0].Rows[0];
        }
        catch
        {
            Session["username"] = null;
            Session["user_id"] = null;
            Session["correo_inst"] = null;
            Session["data_user"] = null;
        }
        try
        {
            string url = respuesta[1].Rows[0]["response"].ToString();
            Response.Redirect(login.validacionurl(url));
        }
        catch
        {
            //LMensaje.Text = "Algo Ha Salido mal x2 :")";
        }
    }
}