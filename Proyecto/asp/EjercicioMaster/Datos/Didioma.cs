using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;

namespace Datos
{
    public class Didioma
    {
        public DataTable cargar_idiomas()
        {
            DataTable datos = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_cargar_idiomas", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                conectar.Open();
                dataAdapter.Fill(datos);
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
            return datos;
        }
        public DataTable obtenerIdioma(Int32 formulario, Int32 idioma)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_idioma_formulario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_formulario_id", NpgsqlDbType.Integer).Value = formulario;
                dataAdapter.SelectCommand.Parameters.Add("_idioma_id", NpgsqlDbType.Integer).Value = idioma;

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
        public DataTable agregarIdioma(String idioma,String term)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_ingresar_idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_idioma", NpgsqlDbType.Varchar).Value = idioma;
                dataAdapter.SelectCommand.Parameters.Add("_cultura", NpgsqlDbType.Varchar).Value = term;

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
        public DataTable cargar_form()
        {
            DataTable datos = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_formulario", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                conectar.Open();
                dataAdapter.Fill(datos);
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
            return datos;
        }
    }
}
