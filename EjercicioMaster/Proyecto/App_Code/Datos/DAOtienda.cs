using System;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

/// <summary>
/// Descripción breve de DAOtienda
/// </summary>
public class DAOtienda
{
    public DAOtienda()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable consultar_login(Elogin sesion)
    {
        DataTable sesiones = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_consultar_login", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;            
            dataAdapter.SelectCommand.Parameters.Add("_username", NpgsqlDbType.Varchar).Value = sesion.Username;
            dataAdapter.SelectCommand.Parameters.Add("_password", NpgsqlDbType.Varchar).Value = sesion.Password;

            conectar.Open();
            dataAdapter.Fill(sesiones);
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
        return sesiones;
    }
}