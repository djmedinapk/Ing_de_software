using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Data;

namespace Logica
{
    public class LresetPass
    {
        public String[] reset(String TResetPassUser)
        {
            String[] respuesta = new String[2];
            DResetPass reset = new DResetPass();
            System.Data.DataTable validez = reset.GenerarToken(TResetPassUser);

            if (int.Parse(validez.Rows[0]["id"].ToString()) > 0 && int.Parse(validez.Rows[0]["estado_session"].ToString()) == 1)
            {
                
                UuserToken token = new UuserToken();
                token.Id = int.Parse(validez.Rows[0]["id"].ToString());
                token.User_name = validez.Rows[0]["username"].ToString();
                token.Estado = int.Parse(validez.Rows[0]["estado_session"].ToString());
                token.Correo = validez.Rows[0]["correo"].ToString();
                DateTime actual = DateTime.Now;
                long fecha_actual = actual.Ticks;
                token.Fecha = fecha_actual;
                String Token_json = JsonConvert.SerializeObject(token);
                String userToken = Encriptar(Token_json);
                reset.AlmacenarToken(userToken, token.Id);
                Lcorreo correo = new Lcorreo();
                String mensaje = "<html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /><title>Untitled Document</title></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0'>  <tr>  " +
                    "  <td align='center' valign='top' bgcolor='#FFFFFF' style='background-color:#FFFFFF;'><br>    <tr>        <td colspan='2' align='left' valign='top' bgcolor='#078B0A' style='background-color:#078B0A; padding:10px; font-family:Arial; color:#FFFFFF; font-size:60px;'>ForoUdec</td>    " +
                    "    </tr>        <td colspan='2' align='left' valign='top' bgcolor='#F2FB06' style='background-color:#F2FB06; padding:5px;'></td>        </tr>      <tr>      <tr>      <td style='background-color:#666666; width:100px; '>      	      </td>          " +
                    "  <td align='left' valign='top' style='font-family:Verdana, sans-serif; color:#232222;'>            <div style='font-size:24px;'><b>Recuperar Contraseña</b></div>            <div style='font-size:14px;'><br>              <p>Para recuperar la contraseña has click en <b>Cambiar Contraseña</b>.</p></div>    " +
                    "           <div><br><br><a href='" + "http://localhost:60249/View/login/nueva_contraseña.aspx?" + userToken + "'>                 <input type='button'  name='finalizar' value='Cambiar Contraseña' style=' background-color:#1B5EF6; padding: 20px; width: 100%; align-content: center; color: #FFFFFF; font-size: 25px; border-radius: 10px;'></a></div>  " +
                    "             <div style='font-size:11px;'><br><br><br>              No puedes ver bien el correo, entonces accede al siguiente link:  <br>              <br>              <br>               </div>               <div style='font-size:11px; color:#0cade3;'><b>               " +
                    "	<a href='" + "http://localhost:60249/View/login/nueva_contraseña.aspx?" + userToken + "'>" + "http://localhost:60249/View/login/nueva_contraseña.aspx?" + userToken + "</a>               </b></div>               <div style='font-size:11px;'><br>                " +
                    " ForoUdec 2017 © Todos Los Derechos Reservados <br>  <br>               </div></td>          </tr>    <br>        </table>    <br>    <br></td>  </tr></table></body></html>";
                correo.enviarCorreo(token.Correo, userToken, mensaje);
                respuesta[0] = "Green";
                respuesta[1] = "Se ha enviado un link de acceso a su correo electrónico";
                reset.ActualizarEstado(token.User_name);
            }
            else if (int.Parse(validez.Rows[0]["estado_session"].ToString()) == 2)
            {
                respuesta[0] = "Blue";
                respuesta[1] = "Ya existe una solicitud de restablecimiento, por favor revise su correo electrónico";
            }
            else
            {
                respuesta[0] = "Red";
                respuesta[1] = "El usuario digitado no se encuentra registrado";
            }
            return respuesta;
        }

        private string Encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public String validar(String token)
        {
            String respuesta = null;
            DResetPass validacion = new DResetPass();
            DataTable validez = validacion.Validartoken(token);
            if (int.Parse(validez.Rows[0][0].ToString()) != 1)
            {
               respuesta="ingresar.aspx";
            }
            else
            {
                respuesta = null;
            }
            return respuesta; 
        }
        public String[] cambiarpass(String TNewPassUser,String token)
        {
            String[] respuesta = new String[3];
            DResetPass reset = new DResetPass();
            encryption encript = new encryption();
            System.Data.DataTable validez = reset.CambiarContraseña(encript.encrypto(TNewPassUser), token);
            if (int.Parse(validez.Rows[0][0].ToString()) == 1)
            {
                respuesta[0] ="Green";
                respuesta[1] = "Su contraseña ha sido restablecida";
                respuesta[2]="redirect_login.aspx";
            }
            else if (int.Parse(validez.Rows[0].ToString()) == 0)
            {
                respuesta[0] = "Red";
                respuesta[1] = "No puede cambiarse la contraseña";
                respuesta[2] = null;
            }
            return respuesta;
        }
        
    }
}
