using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Configuration;

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
    
    //public DataTable llenar_reporte_usuario()
    //{
    //    DataTable Usuario = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("pruebas.f_reporte_usuario", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
   
    //public DataTable llenar_reporte_publicacion()
    //{
    //    DataTable Usuario = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("pruebas.f_reporte_publicacion", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    //public DataTable llenar_reporte_puntuacion()
    //{
    //    DataTable Usuario = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(" pruebas.f_reporte_puntuacion", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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