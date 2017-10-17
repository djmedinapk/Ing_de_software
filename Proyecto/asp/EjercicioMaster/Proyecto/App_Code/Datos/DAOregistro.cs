using System;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
/// <summary>
/// Descripción breve de DAOregistro
/// </summary>
public class DAOregistro
{
    public DAOregistro()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable registro(Eregistro datos)
    {
        DataTable verificacion = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_registro_usuario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_username", NpgsqlDbType.Varchar).Value = datos.Username;
            dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Varchar).Value = datos.Password;
            dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar).Value = datos.Correo;

            conectar.Open();
            dataAdapter.Fill(verificacion);
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
        return verificacion;
    }
}