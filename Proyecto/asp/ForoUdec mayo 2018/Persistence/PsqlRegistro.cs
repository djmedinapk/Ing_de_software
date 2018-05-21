using Encapsulados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Persistence
{
    public class PsqlRegistro
    {
        public DataTable registro(Eadmin_actualizar_usuario datos)
        {
            DataTable datos1 = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_registro_usuario(datos.Username,datos.Password,datos.Correo,datos.Session).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos1 = salida.ConvertToDataTable(a);
            }
            return datos1;


        }
    }
}