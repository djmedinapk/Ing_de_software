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
}