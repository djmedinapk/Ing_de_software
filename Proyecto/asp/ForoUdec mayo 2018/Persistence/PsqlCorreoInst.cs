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
        public DataTable traerCorreoInstitucional(int user_id)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_traer_correo_institucional(user_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
                
            }
            return datos;


        }
    }
}
