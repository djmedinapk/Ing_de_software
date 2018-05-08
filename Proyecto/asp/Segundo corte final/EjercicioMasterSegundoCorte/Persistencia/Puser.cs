using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tablas;

namespace Persistencia
{
    public class Puser
    {
        public user_session traerUser(Int32 id) {

            using (ForoUdecContext db = new ForoUdecContext("usuario"))
            {
                user_session user = db.user_sessiones.Find(id);
                return user;
            }

        }
    }
}
