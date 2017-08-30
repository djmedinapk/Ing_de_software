using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;

/// <summary>
/// Descripción breve de DAOuser
/// </summary>
public class DAOuser
{
    public DAOuser()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable insertarUsuario(Euser user)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_insertar_usuario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_Nombre", NpgsqlDbType.Varchar).Value = user.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_Username", NpgsqlDbType.Varchar).Value = user.Username;
            dataAdapter.SelectCommand.Parameters.Add("_Clave", NpgsqlDbType.Varchar).Value = user.Clave;
            dataAdapter.SelectCommand.Parameters.Add("_Telefono", NpgsqlDbType.Varchar).Value = user.Telefono;
            dataAdapter.SelectCommand.Parameters.Add("_Email", NpgsqlDbType.Varchar).Value = user.Email;
            dataAdapter.SelectCommand.Parameters.Add("_Profesion", NpgsqlDbType.Varchar).Value = user.Profesion;
            conectar.Open();
            dataAdapter.Fill(Usuario);
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
        return Usuario;
    }

    public DataTable obtenerUsuario(String condicion1, String condicion2, String condicion3)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_usuario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_condicion1", NpgsqlDbType.Varchar).Value = condicion1;
            dataAdapter.SelectCommand.Parameters.Add("_Condicion2", NpgsqlDbType.Varchar).Value = condicion2;
            dataAdapter.SelectCommand.Parameters.Add("_Condicion3", NpgsqlDbType.Varchar).Value = condicion3;
            conectar.Open();
            dataAdapter.Fill(Usuario);
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
        return Usuario;
    }


}