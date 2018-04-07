using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using System.Collections;

public partial class view_perfil_correoInstitucional : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LverificarSesion verificarsesion = new LverificarSesion();
        try
        {
            Response.Redirect(verificarsesion.verificar_sesion((DataRow)Session["data_user"], "~\\view\\login\\ingresar.aspx"));
        }
        catch {
            Lotros postb = new Lotros();
            panelM.Visible = postb.aux3(IsPostBack);
            panelV.Visible = !postb.aux3(IsPostBack);
        }
        //var papas = (DataRow)Session["data_user"];
        //if (papas == null)
        //{
        //    Session["username"] = null;
        //    Session["user_id"] = null;
        //    Session["Iperfil_url"] = null;
        //    Session["data_user"] = null;
        //    Response.Redirect("~\\view\\login\\ingresar.aspx");
        //}
        //else
        //{
        //    if (!IsPostBack)
        //    {
        //        panelM.Visible = true;
        //        panelV.Visible = false;
        //    }

        //}
        Int32 idioma = 2;
        Int32 id_pagina = 13;
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
        L_registrar_correo.Text = controles["L_registrar_correo"].ToString();
        Bterminar.Text = controles["Bterminar"].ToString();
        L_verificar.Text = controles["L_verificar"].ToString();
        Bcodigo.Text = controles["Bcodigo"].ToString();
        L_volver1.Text = controles["L_volver1"].ToString();

    }

    protected void Bterminar_Click(object sender, EventArgs e)
    {
        String mail = Tcorreo.Text.ToLower()+"@ucundinamarca.edu.co";
        LPerfil enviarcodigo = new LPerfil();
        clave.Text = enviarcodigo.enviarcodigo(mail);
        panelM.Visible = false;
        panelV.Visible = true;
        //String mensaje;
        //String tipoMensaje;
        //var papas = (DataRow)Session["data_user"];
        //Int32 id = Int32.Parse(papas["id"].ToString());
        //String mail = Tcorreo.Text.ToLower();
        //DAOperfil perfil = new DAOperfil();
        //DataTable msg = perfil.RegistrarCorreoInstitucional(id,mail,Session.SessionID);
        //if (msg.Rows.Count > 0)
        //{
        //    mensaje = msg.Rows[0][0].ToString();
        //    tipoMensaje = "verde";
        //}
        //else
        //{
        //    mensaje = "Fallo En la Inserccion";
        //    tipoMensaje = "rojo";
        //}
        //Lalert.Text = Alerta(mensaje,tipoMensaje);

    }
    protected void Bcodigo_Click(object sender, EventArgs e)
    {
        //String mensaje;
        //String tipoMensaje;
        //var papas = (DataRow)Session["data_user"];
        //Int32 id = Int32.Parse(papas["id"].ToString());
        //String mail = Tcorreo.Text.ToLower()+"@ucundinamarca.edu.co";
        //String codigo = Tcodigo.Text;
        //String Codigoold = clave.Text;
        //if (codigo == Codigoold)
        //{
        //    DAOperfil perfil = new DAOperfil();
        //    DataTable msg = perfil.RegistrarCorreoInstitucional(id, mail, Session.SessionID);
        //    if (msg.Rows.Count > 0)
        //    {
        //        mensaje = msg.Rows[0][0].ToString();
        //        tipoMensaje = "verde";
        //    }
        //    else
        //    {
        //        mensaje = "Fallo En la Inserccion";
        //        tipoMensaje = "rojo";
        //    }
        //}
        //else
        //{
        //    mensaje = "El codigo no es correcto, por favor revisa tu correo y verifica el Codigo enviado<br>O revisa la bandeja de correos no deseados";
        //    tipoMensaje = "amarillo";
        //}
        UcorreoInst datos = new UcorreoInst();
        datos.Email = Tcorreo.Text;
        datos.Clave= clave.Text;
        datos.Tcodigo= Tcodigo.Text;
        datos.Cecion = Session.SessionID;
        LcorreoInst verificar = new LcorreoInst();
        Lalert.Text = verificar.registrar_correo((DataRow)Session["data_user"],datos);

    }
    
}