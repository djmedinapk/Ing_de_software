using System;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

/// <summary>
/// Descripción breve de DAOpost
/// </summary>
public class DAOpost
{
    public DAOpost()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable listar_categoria()
    {
        DataTable categoria = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("post.f_listar_categoria", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataTable ingresar_post(Epost datosPost, int user_id,String Sesion)
    {
        DataTable categoria = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("post.f_ingresar_post", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_sesion", NpgsqlDbType.Varchar).Value = Sesion;
            dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value =user_id;
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
   
    public DataTable ver_post(int post_id)
    {
        DataTable post = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("post.f_ver_post", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataTable ver_post_home(string orden)
    {
        DataTable post = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("post.f_listar_post_home", conectar);
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
    public DataTable visita_post(int post_id)
    {
        DataTable post = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(" post.f_visita_post", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
}