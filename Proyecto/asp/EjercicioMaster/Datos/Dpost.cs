using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encapsulados;

namespace Datos
{
    public class Dpost
    {
        public DataTable ingresar_post(Epublicacion datosPost, int user_id, String Sesion, int modo)
        {
            DataTable categoria = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = null;

                if (modo == 1)
                {
                    dataAdapter = new NpgsqlDataAdapter("post.f_ingresar_post_privado", conectar);
                }
                else
                {
                    dataAdapter = new NpgsqlDataAdapter("post.f_ingresar_post", conectar);
                }

                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_sesion", NpgsqlDbType.Varchar).Value = Sesion;
                dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = user_id;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar).Value = datosPost.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Varchar).Value = datosPost.Descripcion;
                dataAdapter.SelectCommand.Parameters.Add("_categoria", NpgsqlDbType.Integer).Value = datosPost.Categoria;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Varchar).Value = datosPost.Contenido;
                dataAdapter.SelectCommand.Parameters.Add("_autor", NpgsqlDbType.Varchar).Value = datosPost.Autor;
                dataAdapter.SelectCommand.Parameters.Add("_miniatura", NpgsqlDbType.Varchar).Value = datosPost.Miniatura;
                dataAdapter.SelectCommand.Parameters.Add("_etiquetas", NpgsqlDbType.Varchar).Value = datosPost.Etiquetas;

                conectar.Open();
                dataAdapter.Fill(categoria);
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
            return categoria;
        }
        public DataTable eliminar_post(int post_id, String Sesion)
        {
            DataTable post = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(" post.f_suspender_post", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_sesion", NpgsqlDbType.Text).Value = Sesion;
                dataAdapter.SelectCommand.Parameters.Add("_postid", NpgsqlDbType.Integer).Value = post_id;

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
        public DataTable cargar_mod_post(Int32 post_id, Int32 user_id)
        {
            DataTable post = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(" post.f_cargar_mod_post", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_usertid", NpgsqlDbType.Integer).Value = user_id;
                dataAdapter.SelectCommand.Parameters.Add("_postid", NpgsqlDbType.Integer).Value = post_id;

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

        public DataTable modificar_post(Epublicacion datosPost, int user_id, String Sesion, int post_id)
        {
            DataTable categoria = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("post.f_modificar_post", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_sesion", NpgsqlDbType.Varchar).Value = Sesion;
                dataAdapter.SelectCommand.Parameters.Add("_postid", NpgsqlDbType.Integer).Value = post_id;
                dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = user_id;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar).Value = datosPost.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Varchar).Value = datosPost.Descripcion;
                dataAdapter.SelectCommand.Parameters.Add("_categoria", NpgsqlDbType.Integer).Value = datosPost.Categoria;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Varchar).Value = datosPost.Contenido;
                dataAdapter.SelectCommand.Parameters.Add("_autor", NpgsqlDbType.Varchar).Value = datosPost.Autor;
                dataAdapter.SelectCommand.Parameters.Add("_miniatura", NpgsqlDbType.Varchar).Value = datosPost.Miniatura;
                dataAdapter.SelectCommand.Parameters.Add("_etiquetas", NpgsqlDbType.Varchar).Value = datosPost.Etiquetas;

                conectar.Open();
                dataAdapter.Fill(categoria);
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
            return categoria;
        }
    }
}
