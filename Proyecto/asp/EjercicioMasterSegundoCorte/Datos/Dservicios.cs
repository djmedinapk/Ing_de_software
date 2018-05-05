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
    public class Dservicios
    {
        public DataSet ver_post_home_categoria(string orden)
        {
            DataSet post = new DataSet();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres1"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("post.f_listar_post_home_servicios", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_orden", NpgsqlDbType.Varchar).Value = orden;

                conectar.Open();
                dataAdapter.Fill(post);
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
            return post;
        }
        public DataTable login(String username, String pass)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres1"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad_registros.f_loggin", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_user_name", NpgsqlDbType.Varchar, 100).Value = username;
                dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = pass;
                conection.Open();
                dataAdapter.Fill(Usuario);
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
            return Usuario;
        }
        public DataTable validarToken(String token, String fuente)
        {
            //ejemplo base de datos con token
            DataTable tokens = new DataTable();
            tokens.Columns.Add("Id");
            tokens.Columns.Add("token");
            tokens.Columns.Add("fuente");
            ///fin- ejemplo
            ///tabla de datos ejemplo de respuesta del postgres
            DataTable dt = new DataTable();
            dt.Columns.Add("respuesta");
            ///fin-ejemplo

            DataRow row = tokens.NewRow();
            row["Id"] = 1;
            row["token"] = "21sad81asda328as15d1bsd8b4a121d8g44j21lji513j-app";
            row["fuente"] = "Ionic";
            tokens.Rows.Add(row);
            DataRow row2 = tokens.NewRow();
            row2["Id"] = 2;
            row2["token"] = "11221312ds2d1asd5qd1321daaf32sse24213412321da-mtb";
            row2["fuente"] = "mtb-competence";
            tokens.Rows.Add(row2);

            for (int i = 0; i < tokens.Rows.Count; i++)
            {
                if (tokens.Rows[i][1].ToString() == token && tokens.Rows[i][2].ToString() == fuente)
                {
                    DataRow auxrow = dt.NewRow();
                    auxrow["respuesta"] = "true";
                    dt.Rows.Add(auxrow);
                }
            }

            return dt;
        }
    }
}
