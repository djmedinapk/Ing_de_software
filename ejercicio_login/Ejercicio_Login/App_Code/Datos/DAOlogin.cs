using System;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de DAOlogin
/// </summary>
public class DAOlogin
{
    public DAOlogin()
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
            dataAdapter.SelectCommand.Parameters.Add("_Password", NpgsqlDbType.Varchar).Value = sesion.Password;
            dataAdapter.SelectCommand.Parameters.Add("_Username", NpgsqlDbType.Varchar).Value = sesion.Username;
            
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
        }return sesiones;
    }
}