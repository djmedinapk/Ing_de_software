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
using System.Collections;

public partial class view_login_ingresar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LverificarSesion verificar = new LverificarSesion();//"U1", "M1", "U2","M2",
        //String[] permisos = new String[] { "AD" };
        try
        {
            String url = verificar.verificar_sesion2((DataRow)Session["data_user"], "../perfil/perfil.aspx");
            Response.Redirect(url);
        }
        catch {
            //String b = verificar.verificar_permisos((DataRow)Session["data_user"], permisos, "../home/index.aspx");
            //int a = 0;
        }
        //if (Session["username"] == null || Session["user_id"] == null)
        //{
        //    Session["username"] = null;
        //    Session["user_id"] = null;

        //}
        //else
        //{

        //}
        Int32 idioma = 2;
        Int32 id_pagina = 8;
        try
        {
            idioma = Int32.Parse(Session["idioma"].ToString());
            Lotros post = new Lotros();
        }
        catch
        {
            idioma = 2;
        }

        Lidioma cargar_controles = new Lidioma();
        Hashtable controles = cargar_controles.cargar_controles(id_pagina, idioma);

        L_iniciar_sesion.Text = controles["L_iniciar_sesion"].ToString();
        L_registrarse.Text = controles["L_registrarse"].ToString();
        TloginUser.Attributes["placeholder"] = controles["TloginUser"].ToString();
        TloginPassword.Attributes["placeholder"] = controles["TloginPassword"].ToString();
        Blogin.Text = controles["Blogin"].ToString();
        L_recuperar_contraseña.Text = controles["L_recuperar_contraseña"].ToString();
        TregistroCorreo.Attributes["placeholder"] = controles["TregistroCorreo"].ToString();
        TregistroUser.Attributes["placeholder"] = controles["TregistroUser"].ToString();
        TregistroPassword.Attributes["placeholder"] = controles["TregistroPassword"].ToString();
        TregistroPassword2.Attributes["placeholder"] = controles["TregistroPassword2"].ToString();
        Bregistro.Text = controles["Bregistro"].ToString();


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