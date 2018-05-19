using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encapsulados;
using Npgsql;
using System.Configuration;
using NpgsqlTypes;

namespace Datos
{
    public class Dregistro
    {
        public DataTable registro(Eadmin_actualizar_usuario datos)
        {
            DataTable verificacion = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_registro_usuario", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_username", NpgsqlDbType.Varchar).Value = datos.Username;
                dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Varchar).Value = datos.Password;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar).Value = datos.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Varchar).Value = datos.Session;

                conectar.Open();
                dataAdapter.Fill(verificacion);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conectar != null)
                {
                    conectar.Close();
                }
            }
            return verificacion;
        }
    }
}
