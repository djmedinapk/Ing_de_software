using Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class PsqlCorreoInst
    {
        public String traerCorreoInstitucional(int user_id)
        {
            String datos;

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                List<String> a = db.f_traer_correo_institucional(user_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                try {
                    datos = a.First().ToString();

                }
                catch { datos = null; }
               
                
            }
            return datos;


        }
    }
}
