using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DcorreoInst
    {
        public DataTable traerCorreoInstitucional(int user_id)
        {
            DataTable correo = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_traer_correo_institucional", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                // dataAdapter.SelectCommand.Parameters.Add("_username", NpgsqlDbType.Varchar).Value = username;
                dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = user_id;
                conection.Open();
                dataAdapter.Fill(correo);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return correo;
        }
    }
}
