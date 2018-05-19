using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tablas;

namespace Persistencia
{
     public class Pcontacto
    {
        public void enviarSolicitud(Contacto datos)
        {
            using (ForoUdecContext db = new ForoUdecContext("public"))
            {
                db.contactos.Add(datos);
                db.SaveChanges();

               
            }
        }
    }
}
