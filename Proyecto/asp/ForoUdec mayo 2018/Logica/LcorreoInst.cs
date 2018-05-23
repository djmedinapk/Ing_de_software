using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using System.Data;
using Persistence;

namespace Logica
{
    public class LcorreoInst
    {
        public String registrar_correo(DataRow sesion,UcorreoInst correo)
        {
            String mensaje;
            String tipoMensaje;
            Int32 id = Int32.Parse(sesion["id"].ToString());
            String mail = correo.Email.ToLower() + "@ucundinamarca.edu.co";
            String codigo = correo.Tcodigo;
            String Codigoold = correo.Clave;
            if (codigo == Codigoold)
            {
                //Dperfil perfil = new Dperfil();
                PsqlPerfil perfil = new PsqlPerfil();
                string msg = perfil.RegistrarCorreoInstitucional(id, mail, correo.Cecion);
                if (msg != null)
                {
                    mensaje = msg.ToString();
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

            String Lalert = Alerta(mensaje, tipoMensaje);
            return Lalert;
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
}
