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

    public DataTable obtenerUsuario()
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_usuario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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


    public DataTable obtenerEmpresa(String valor1)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_empresa", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_condicion1", NpgsqlDbType.Varchar).Value = valor1;
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

    public DataTable obtenerProductos(String valor1, String valor2)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_productos", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_condicion1", NpgsqlDbType.Varchar).Value = valor1;
            dataAdapter.SelectCommand.Parameters.Add("_condicion2", NpgsqlDbType.Varchar).Value = valor2;
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


    public DataTable obtenerProductos(String valor1, Int32 valor2)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_productos", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_condicion1", NpgsqlDbType.Varchar).Value = valor1;
            dataAdapter.SelectCommand.Parameters.Add("_condicion2", NpgsqlDbType.Varchar).Value = valor2;
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

    public DataTable obtenerEstudios(String valor1, Int32 valor2,String valor3)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_estudios", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_condicion1", NpgsqlDbType.Varchar).Value = valor1;
            dataAdapter.SelectCommand.Parameters.Add("_condicion2", NpgsqlDbType.Varchar).Value = valor2;
            dataAdapter.SelectCommand.Parameters.Add("_condicion3", NpgsqlDbType.Varchar).Value = valor3;
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