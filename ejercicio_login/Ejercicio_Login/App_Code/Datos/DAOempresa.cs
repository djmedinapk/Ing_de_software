using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOempresa
/// </summary>
public class DAOempresa
{
    public DAOempresa()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable insertar_empresa(Eempresa empresas)
    {
        DataTable empresa = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_insertar_empresa", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_Username", NpgsqlDbType.Varchar).Value = empresas.Username;
            dataAdapter.SelectCommand.Parameters.Add("_Nombre_empresa", NpgsqlDbType.Varchar).Value = empresas.Nombre_empresa;
            dataAdapter.SelectCommand.Parameters.Add("_Cargo_empresa", NpgsqlDbType.Varchar).Value = empresas.Cargo_empresa;
            dataAdapter.SelectCommand.Parameters.Add("_Tiempo_empresa", NpgsqlDbType.Varchar).Value = empresas.Tiempo_empresa;
            dataAdapter.SelectCommand.Parameters.Add("_Jefe_empresa", NpgsqlDbType.Varchar).Value = empresas.Jefe_empresa;
            conectar.Open();
            dataAdapter.Fill(empresa);
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
        return empresa;
    }
}