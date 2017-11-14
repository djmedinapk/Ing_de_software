using System;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

/// <summary>
/// Descripción breve de DAOdenuncia
/// </summary>
public class DAOdenuncia
{
    public DAOdenuncia()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable denuncia_comentario(int user_id, int comentario_id,String descripcion)
    {
        DataTable respuesta = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("denuncia.f_denunciar_comentario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_postid", NpgsqlDbType.Integer).Value = user_id;
            dataAdapter.SelectCommand.Parameters.Add("_comentarioid", NpgsqlDbType.Integer).Value = comentario_id;
            dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Text).Value = descripcion;

            conectar.Open();
            dataAdapter.Fill(respuesta);
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
        return respuesta;
    }
    public DataTable denuncia_publicacion(int user_id, int publicacion_id, String descripcion)
    {
        DataTable respuesta = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("denuncia.f_denunciar_publicacion", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = user_id;
            dataAdapter.SelectCommand.Parameters.Add("_postid", NpgsqlDbType.Integer).Value = publicacion_id;
            dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Text).Value = descripcion;

            conectar.Open();
            dataAdapter.Fill(respuesta);
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
        return respuesta;
    }
    public DataTable mostar_denuncia_comentario()
    {
        DataTable respuesta = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("denuncia.f_mostar_denuncias_comentario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            conectar.Open();
            dataAdapter.Fill(respuesta);
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
        return respuesta;
    }
    public DataTable eliminar_denuncia_comentario(int id_denuncia)
    {
        DataTable respuesta = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("denuncia.f_eliminar_denuncia_comentario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_denunciaid", NpgsqlDbType.Integer).Value = id_denuncia;
            conectar.Open();
            dataAdapter.Fill(respuesta);
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
        return respuesta;
    }
}