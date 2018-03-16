using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOResetPass
/// </summary>
public class DAOResetPass
{
    public DAOResetPass()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    //public DataTable GenerarToken(String user_name)
    //{
    //    DataTable Usuario = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_validar_usuario", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dataAdapter.SelectCommand.Parameters.Add("_user_name", NpgsqlDbType.Text).Value = user_name;
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
    //public DataTable AlmacenarToken(String token, Int32 userId)
    //{
    //    DataTable Usuario = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_almacenar_token", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dataAdapter.SelectCommand.Parameters.Add("_token", NpgsqlDbType.Text).Value = token;
    //        dataAdapter.SelectCommand.Parameters.Add("_user_id", NpgsqlDbType.Integer).Value = userId;

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


    //public DataTable ActualizarEstado(String user_name)
    //{
    //    DataTable Usuario = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.actualizar_estado", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dataAdapter.SelectCommand.Parameters.Add("_user_name", NpgsqlDbType.Text).Value = user_name;
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

    //public DataTable CambiarContraseña(String clave,String token)
    //{
    //    DataTable contraseña = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_cambiar_password", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dataAdapter.SelectCommand.Parameters.Add("_password", NpgsqlDbType.Varchar).Value = clave;
    //        dataAdapter.SelectCommand.Parameters.Add("_token", NpgsqlDbType.Text).Value = token;
    //        conection.Open();
    //        dataAdapter.Fill(contraseña);
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
    //    return contraseña;
    //}

    //public DataTable Validartoken(String _token)
    //{
    //    DataTable token = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_validar_token", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dataAdapter.SelectCommand.Parameters.Add("_token", NpgsqlDbType.Text).Value = _token;
    //        conection.Open();
    //        dataAdapter.Fill(token);
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
    //    return token;
    //}




}