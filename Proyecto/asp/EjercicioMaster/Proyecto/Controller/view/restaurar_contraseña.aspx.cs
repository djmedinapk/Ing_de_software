using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_restaurar_contraseña : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_respuesta.Text = "";
    }

    protected void B_recuperar_Click(object sender, EventArgs e)
    {
        DAOResetPass reset = new DAOResetPass();
        System.Data.DataTable validez = reset.GenerarToken(TResetPassUser.Text);

        if (int.Parse(validez.Rows[0]["id"].ToString()) > 0 && int.Parse(validez.Rows[0]["estado_session"].ToString()) == 2 )
        {
            EuserToken token = new EuserToken();
            token.Id = int.Parse(validez.Rows[0]["id"].ToString());
            token.User_name = validez.Rows[0]["username"].ToString();
            token.Estado = int.Parse(validez.Rows[0]["estado_session"].ToString());
            token.Correo = validez.Rows[0]["correo"].ToString();
            String Token_json = JsonConvert.SerializeObject(token);
            String userToken = encriptar(Token_json);
            reset.AlmacenarToken(userToken, token.Id);
            Correo correo = new Correo();
            String mensaje = "<html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /><title>Untitled Document</title></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0'>  <tr>    <td align='center' valign='top' bgcolor='#FFFFFF' style='background-color:#FFFFFF;'><br>    <tr>        <td colspan='2' align='left' valign='top' bgcolor='#078B0A' style='background-color:#078B0A; padding:10px; font-family:Arial; color:#FFFFFF; font-size:60px;'>ForoUdec</td>        </tr>        <td colspan='2' align='left' valign='top' bgcolor='#F2FB06' style='background-color:#F2FB06; padding:5px;'></td>        </tr>      <tr>      <tr>      <td style='background-color:#666666; width:100px; '>      	      </td>            <td align='left' valign='top' style='font-family:Verdana, sans-serif; color:#232222;'>            <div style='font-size:24px;'><b>Recuperar Contraseña</b></div>            <div style='font-size:14px;'><br>              <p>Para recuperar la contraseña has click en <b>Cambiar Contraseña</b>.</p></div>               <div><br><br><a href='" + "http://localhost:60249/View/login/nueva_contraseña.aspx?" + userToken + "'>                 <input type='button'  name='finalizar' value='Cambiar Contraseña' style=' background-color:#1B5EF6; padding: 20px; width: 100%; align-content: center; color: #FFFFFF; font-size: 25px; border-radius: 10px;'></a></div>               <div style='font-size:11px;'><br><br><br>              No puedes ver bien el correo, entonces accede al siguiente link:  <br>              <br>              <br>               </div>               <div style='font-size:11px; color:#0cade3;'><b>               	<a href='" + "http://localhost:60249/View/login/nueva_contraseña.aspx?" + userToken + "'>" + "http://localhost:60249/View/login/nueva_contraseña.aspx?" + userToken + "</a>               </b></div>               <div style='font-size:11px;'><br>                 ForoUdec 2017 © Todos Los Derechos Reservados <br>  <br>               </div></td>          </tr>    <br>        </table>    <br>    <br></td>  </tr></table></body></html>";
            correo.enviarCorreo(token.Correo, userToken, mensaje);
            L_respuesta.ForeColor = System.Drawing.Color.Green;
            L_respuesta.Text = "Se ha enviado un link de acceso a su correo electrónico";
            reset.ActualizarEstado(token.User_name);
        }
        else if (int.Parse(validez.Rows[0]["estado_session"].ToString()) == 2)
        {
            L_respuesta.ForeColor = System.Drawing.Color.Blue;
            L_respuesta.Text = "Ya existe una solicitud de restablecimiento, por favor revise su correo electrónico";
        }
        else
        {
            L_respuesta.ForeColor = System.Drawing.Color.Red;
            L_respuesta.Text = "El usuario digitado no se encuentra registrado";
        }
    }

    private string encriptar(string input)
    {
        SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedBytes = provider.ComputeHash(inputBytes);

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < hashedBytes.Length; i++)
            output.Append(hashedBytes[i].ToString("x2").ToLower());

        return output.ToString();
    }
}