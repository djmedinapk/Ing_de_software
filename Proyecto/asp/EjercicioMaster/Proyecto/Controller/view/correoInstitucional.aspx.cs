using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_perfil_correoInstitucional : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var papas = (DataRow)Session["data_user"];
        if (papas == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;
            Session["Iperfil_url"] = null;
            Session["data_user"] = null;
            Response.Redirect("~\\view\\login\\ingresar.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                panelM.Visible = true;
                panelV.Visible = false;
            }
            
        }
    }

    protected void Bterminar_Click(object sender, EventArgs e)
    {
        String mail = Tcorreo.Text.ToLower();
        //-------------codigo ramdom para verificar token fuente:http://joefay.blogspot.com.co/2012/04/generar-cadenas-de-texto-aleatorio.html
        Random obj = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            int longitudnuevacadena = 5;
            string nuevacadena = "";
            for (int i = 0; i < longitudnuevacadena; i++)
            {
               letra = posibles[obj.Next(longitud)];
               nuevacadena += letra.ToString();
            }
        String auxsinvalor = nuevacadena;
        Correo correo = new Correo();
        String mensajecorreo = "<html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /><title>Validar Correo</title></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0'>  <tr>  " +
                "  <td align='center' valign='top' bgcolor='#FFFFFF' style='background-color:#FFFFFF;'><br>    <tr>        <td colspan='2' align='left' valign='top' bgcolor='#078B0A' style='background-color:#078B0A; padding:10px; font-family:Arial; color:#FFFFFF; font-size:60px;'>ForoUdec</td>    " +
                "    </tr>        <td colspan='2' align='left' valign='top' bgcolor='#F2FB06' style='background-color:#F2FB06; padding:5px;'></td>        </tr>      <tr>      <tr>      <td style='background-color:#666666; width:100px; '>      	      </td>          " +
                "  <td align='left' valign='top' style='font-family:Verdana, sans-serif; color:#232222;'>            <div style='font-size:24px;'><b>Verificar Correo Institucional</b></div>            <div style='font-size:14px;'><br>              <p>Para registrar el correo ingresa el siguiente codigo de seguridad<br> <b>"+nuevacadena+"</b>.</p></div>    " +
                "             <div style='font-size:11px;'><br>                " +
                " ForoUdec 2017 © Todos Los Derechos Reservados <br>  <br>               </div></td>          </tr>    <br>        </table>    <br>    <br></td>  </tr></table></body></html>";
        //*********************************************************************************
        correo.enviarCorreo(mail, nuevacadena, mensajecorreo);
        clave.Text = nuevacadena;
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
        String mensaje;
        String tipoMensaje;
        var papas = (DataRow)Session["data_user"];
        Int32 id = Int32.Parse(papas["id"].ToString());
        String mail = Tcorreo.Text.ToLower();
        String codigo = Tcodigo.Text;
        String Codigoold = clave.Text;
        if (codigo == Codigoold)
        {
            DAOperfil perfil = new DAOperfil();
            DataTable msg = perfil.RegistrarCorreoInstitucional(id, mail, Session.SessionID);
            if (msg.Rows.Count > 0)
            {
                mensaje = msg.Rows[0][0].ToString();
                tipoMensaje = "verde";
            }
            else
            {
                mensaje = "Fallo En la Inserccion";
                tipoMensaje = "rojo";
            }
        }
        else
        {
            mensaje = "El codigo no es correcto, por favor revisa tu correo y verifica el Codigo enviado<br>O revisa la bandeja de correos no deseados";
            tipoMensaje = "amarillo";
        }
        
        Lalert.Text = Alerta(mensaje, tipoMensaje);

    }
    private String Alerta(String mensaje, String tipo)
    {
        String boton;
        String aux = "dark";
        switch (tipo)
        {
            case "amarillo":
                aux = "warning";
                break;
            case "verde":
                aux = "success";
                break;
            case "azul":
                aux = "primary";
                break;
            case "gris":
                aux = "dark";
                break;
            case "rojo":
                aux = "danger";
                break;
        }
        boton = "<div class='alert alert-" + aux + " alert-dismissible show' role='alert'>" + mensaje +
            "  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>" +
            "    <span aria-hidden='true'>&times;</span>" +
            "  </button>" +
            "</div> ";
        return boton;
    }
}