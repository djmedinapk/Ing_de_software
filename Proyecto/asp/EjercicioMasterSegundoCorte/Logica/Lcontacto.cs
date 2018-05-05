using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Encapsulados;
using Utilitarios;
using Persistencia;
using Tablas;

namespace Logica
{
    public class Lcontacto
    {
        public void enviarSolicitud(Ucontacto contacto)
        {
            contacto datos = new contacto();
            datos.nombre = contacto.Nombre;
            datos.apellido=contacto.Apellido;
            datos.correo=contacto.Correo;
            datos.telefono=contacto.Telefono;
            datos.contenido=contacto.Contenido;
            datos.fecha_solicitud = DateTime.Now;
            Pcontacto solicitud = new Pcontacto();
            solicitud.enviarSolicitud(datos);
            
            //solicitud.Enviar_solicitud(datos);
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
