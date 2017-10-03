using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using Npgsql;
using NpgsqlTypes;

/// <summary>
/// Descripción breve de DAOusuario
/// </summary>
public class DAOusuario
{
    public DAOusuario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable insertarjson(String salida)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("sjson.f_insertar_json", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_json", NpgsqlDbType.Varchar).Value = salida;
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
}