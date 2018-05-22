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
        public String registro(Eadmin_actualizar_usuario datos)
        {
            String datos1;

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                List<string> a= db.f_registro_usuario(datos.Username, datos.Password, datos.Correo, datos.Session).ToList(); 
                ConverToDataTable salida = new ConverToDataTable();
                //datos1 = salida.ConvertToDataTable(a);
                datos1 = a.First().ToString(); 
            }
            return datos1;


        }
    }
}