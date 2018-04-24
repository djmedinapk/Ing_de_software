using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilitarios;
using Utilitarios;

namespace Logica
{
    public class Lcontacto
    {
        public void enviarSolicitud(Ucontacto gg)
        {
            //Dcontacto solicitud = new Dcontacto();
            //contacto datos = new con();
            //datos.Nombre = contacto.nombre;
            //datos.Apellido=contacto.apellido;
            //datos.Correo=contacto.correo;
            //datos.Telefono=contacto.telefono;
            //datos.Contenido=contacto.contenido;
            contacto ct = new contacto();
            ct.nombre = "juan";
            ct.apellido = "juan";
            ct.contenido = "juan";

            //solicitud.Enviar_solicitud(datos);
            Persistencia.Model1Container db = new Persistencia.Model1Container();
            db.contactoes.Add(ct);
            db.SaveChanges();
            Lcorreo correo = new Lcorreo();
            String mensaje = "<!DOCTYPE html><html><head>	<title>Sin titulo</title></head><body style='font-family: Arial'>	" +
                "<div>		<div>			<b>Email: </b> " + ct.correo + "		</div>			<div>		" +
                "	<h4><b>" + ct.nombre + " " + ct.apellido + "</b></h4>		</div>		<div>		" +
                "	<b>Teléfono: </b>" + ct.telefono + "		</div>		<div>		" +
                "	<h4><b>Descripción:</b></h4><br>" + ct.contenido + "</div>	</div></body></html>";
            correo.enviarCorreo(ct.correo, mensaje);
        }
    }
}
