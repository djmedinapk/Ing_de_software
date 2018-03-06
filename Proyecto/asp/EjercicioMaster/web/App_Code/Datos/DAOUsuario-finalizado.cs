using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Configuration;

/// <summary>
/// Descripción breve de DAOUsuario
/// </summary>
public class DAOUsuario
{
    public DAOUsuario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    //public DataTable ingresar(String userio_name, String pass)
    //{
    //    DataTable Usuario = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad_registros.f_loggin", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dataAdapter.SelectCommand.Parameters.Add("_user_name", NpgsqlDbType.Varchar, 100).Value = userio_name;
    //        dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = pass;
    //        conection.Open();
    //        dataAdapter.Fill(Usuario);
    //    }
    //    catch (Exception Ex)
    //    {
    //        throw Ex;
    //    }
    //    finally
    //    {
    //        if (conection != null)
    //        {
    //            conection.Close();
    //        }
    //    }
    //    return Usuario;
    //}

    //public DataTable guardadoSession(Eusuario datos)
    //{
    //    DataTable Usuario = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad_registros.f_guardado_session", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dataAdapter.SelectCommand.Parameters.Add("_user_id", NpgsqlDbType.Integer).Value = datos.UserId;
    //        dataAdapter.SelectCommand.Parameters.Add("_ip", NpgsqlDbType.Varchar, 100).Value = datos.Ip;
    //        dataAdapter.SelectCommand.Parameters.Add("_mac", NpgsqlDbType.Varchar, 100).Value = datos.Mac;
    //        dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = datos.Session;

    //        conection.Open();
    //        dataAdapter.Fill(Usuario);
    //    }
    //    catch (Exception Ex)
    //    {
    //        throw Ex;
    //    }
    //    finally
    //    {
    //        if (conection != null)
    //        {
    //            conection.Close();
    //        }
    //    }
    //    return Usuario;
    //}

    //public DataTable CerrarSession(Eusuario datos)
    //{
    //    DataTable Usuario = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("seguridad_registros.f_cerrar_session", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = datos.Session;

    //        conection.Open();
    //        dataAdapter.Fill(Usuario);
    //    }
    //    catch (Exception Ex)
    //    {
    //        throw Ex;
    //    }
    //    finally
    //    {
    //        if (conection != null)
    //        {
    //            conection.Close();
    //        }
    //    }
    //    return Usuario;
    //}
}
