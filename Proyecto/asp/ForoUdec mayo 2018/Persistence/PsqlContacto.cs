using Encapsulados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class PsqlContacto
    {
        public DataTable Enviar_solicitud(Econtacto solicitud)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_agregar_contacto(solicitud.Nombre, solicitud.Apellido, solicitud.Correo, solicitud.Telefono, solicitud.Contenido);
                
            }
            return datos;
        }
    }
}
