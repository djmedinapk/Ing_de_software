using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOestudios
/// </summary>
public class DAOestudios
{
    public DAOestudios()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable insertar_estudio(Eestudios estudios)
    {
        DataTable estudio = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_insertar_estudios", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_Username", NpgsqlDbType.Varchar).Value = estudios.Username;
            dataAdapter.SelectCommand.Parameters.Add("_Nivel_estudio", NpgsqlDbType.Varchar).Value = estudios.Nivel_estudio ;
            dataAdapter.SelectCommand.Parameters.Add("_Nombre_instituto", NpgsqlDbType.Varchar).Value = estudios.Nombre_instituto;
            dataAdapter.SelectCommand.Parameters.Add("_ciudad_instituto", NpgsqlDbType.Varchar).Value = estudios.Ciudad_instituto;
            dataAdapter.SelectCommand.Parameters.Add("_Año_fin", NpgsqlDbType.Varchar).Value = estudios.Año_fin;
            conectar.Open();
            dataAdapter.Fill(estudio);
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
        return estudio;
    }
}