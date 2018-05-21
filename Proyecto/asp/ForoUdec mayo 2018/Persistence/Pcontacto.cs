using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
     public class Pcontacto
    {
        public void enviarSolicitud(contacto datos)
        {
            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                db.contacto.Add(datos);
                db.SaveChanges();

               
            }
        }
    }
}
