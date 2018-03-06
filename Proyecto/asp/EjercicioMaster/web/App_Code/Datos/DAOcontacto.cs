using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOcontacto
/// </summary>
public class DAOcontacto
{
	public DAOcontacto()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}


    //public DataTable Enviar_solicitud(Econtacto solicitud)
    //{
    //    DataTable contraseña = new DataTable();
    //    NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
    //    try
    //    {
    //        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_agregar_contacto", conection);
    //        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar).Value = solicitud.Nombre;
    //        dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar).Value = solicitud.Apellido;
    //        dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar).Value = solicitud.Correo;
    //        dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Varchar).Value = solicitud.Telefono;
    //        dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = solicitud.Contenido;
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
}