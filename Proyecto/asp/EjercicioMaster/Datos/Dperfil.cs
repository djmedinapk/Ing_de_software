using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encapsulados;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
    public class Dperfil
    {
        public Dperfil()
        {

        }
        public DataTable modificarDatos(int user_id, Eadmin_actualizar_usuario_2 datos, String Sesion)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_modificar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = Sesion;
                dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = user_id;
                //dataAdapter.SelectCommand.Parameters.Add("_username", NpgsqlDbType.Varchar).Value = datos.Username;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar).Value = datos.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar).Value = datos.Apellido;
                //dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar).Value = datos.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_edad", NpgsqlDbType.Integer).Value = datos.Edad;
                dataAdapter.SelectCommand.Parameters.Add("_sexo", NpgsqlDbType.Varchar).Value = datos.Sexo;
                dataAdapter.SelectCommand.Parameters.Add("_avatar", NpgsqlDbType.Varchar).Value = datos.Avatar;

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

        public DataTable traerDatosSesion(int user_id)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_traer_datos_sesion2", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                // dataAdapter.SelectCommand.Parameters.Add("_username", NpgsqlDbType.Varchar).Value = username;
                dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = user_id;
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

        public DataTable modificar_perfil_ajustes(int user_id, String Sesion, Eadmin_actualizar_usuario datos)
        {
            DataTable post = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_modificar_perfil_ajustes", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Varchar).Value = Sesion;
                dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = user_id;
                dataAdapter.SelectCommand.Parameters.Add("_username", NpgsqlDbType.Varchar).Value = datos.Username;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar).Value = datos.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Varchar).Value = datos.Password;

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
    }
}

