
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Persistence
{
    public class PsqlResetPass
    {
            public DataTable GenerarToken(String user_name)
            {
                DataTable datos = new DataTable();

                using (ForoUdecEntities1 db = new ForoUdecEntities1())
                {
                    var a = db.f_validar_usuario(user_name).ToList();
                    ConverToDataTable salida = new ConverToDataTable();
                    datos = salida.ConvertToDataTable(a);

                }

                return datos;
            }

        

        public DataTable AlmacenarToken(String token, Int32 userId)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())

            {
                var a = db.f_almacenar_token(token, userId);

            }
            return datos;
        }

        public DataTable ActualizarEstado(String user_name)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())

            {
                var a = db.f_actualizar_estado(user_name);

            }
            return datos;
        }

        public DataTable CambiarContraseña(String clave, String token)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_cambiar_password(clave, token).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }

        public DataTable Validartoken(String _token)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_validar_token(_token).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }

            return datos;
        }
    }
}