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
        public User_session traerUser(Int32 id) {

            using (ForoUdecContext db = new ForoUdecContext("usuario"))
            {
                User_session user = db.user_sessiones.Find(id);
                return user;
            }

        }
    }
}
