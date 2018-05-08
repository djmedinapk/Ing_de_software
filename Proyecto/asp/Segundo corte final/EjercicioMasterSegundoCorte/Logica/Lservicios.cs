using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Encapsulados;

namespace Logica
{
    public class Lservicios
    {
        public DataSet post(String orden)
        {

            Dservicios solicitud = new Dservicios();
            DataSet datos = solicitud.ver_post_home_categoria(orden);
            return datos;
        }
        public void enviarSolicitud(Ucontacto contacto)
        {
            Econtacto datos = new Econtacto();
            datos.Nombre = contacto.Nombre;
            datos.Apellido = contacto.Apellido;
            datos.Correo = contacto.Correo;
            datos.Telefono = contacto.Telefono;
            datos.Contenido = contacto.Contenido;
           // datos. = DateTime.Now;
            Dcontacto solicitud = new Dcontacto();
            solicitud.Enviar_solicitud(datos);

            solicitud.Enviar_solicitud(datos);
            Lcorreo correo = new Lcorreo();
            String mensaje = "<!DOCTYPE html><html><head>	<title>Sin titulo</title></head><body style='font-family: Arial'>	" +
                "<div>		<div>			<b>Email: </b> " + contacto.Correo + "		</div>			<div>		" +
                "	<h4><b>" + contacto.Nombre + " " + contacto.Apellido + "</b></h4>		</div>		<div>		" +
                "	<b>Teléfono: </b>" + contacto.Telefono + "		</div>		<div>		" +
                "	<h4><b>Descripción:</b></h4><br>" + contacto.Contenido + "</div>	</div></body></html>";
            correo.enviarCorreo(contacto.Correo, mensaje);
        }
    }
}
