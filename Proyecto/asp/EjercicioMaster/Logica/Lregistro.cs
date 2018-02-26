using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using Encapsulados;
using System.Data;

namespace Logica
{
    public class Lregistro
    {
        public String Bregistro(Uadmin_actualizar_usuario usuario)
        {
            String mensaje = null;
            Eadmin_actualizar_usuario datos = new Eadmin_actualizar_usuario();
            datos.Correo = usuario.Correo;
            datos.Username = usuario.Username;
            datos.Session = usuario.Session;

            encryption encriptar = new encryption();

            datos.Password =encriptar.encrypto(usuario.Password);

            Dregistro registro = new Dregistro();
            DataTable informacion = registro.registro(datos);
            if (informacion.Rows.Count != 0)
            {
                string frase = informacion.Rows[0][0].ToString();
                if (frase == "Registro_exitoso")
                {
                     mensaje = "<div class='alert alert-success alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Registro Exitoso!</strong> Gracias Por Ser Parte De Esta Gran Comunidad</div>";
                   
                }
                else
                {
                     mensaje = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Ya se Encuentra en uso este correo  y/o nombre de Usuario!</strong> Si has olvidado tus datos has click en Recuperar Contraseña</div>";
                   
                }

            }
            else
            {

                 mensaje = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Upssss!</strong> Algo ha salido mal intenta recargar la pagina y vuelve a intentarlo</div>";
                
            }

            return mensaje;
        }
    }
}
