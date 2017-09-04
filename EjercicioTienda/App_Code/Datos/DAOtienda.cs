using System;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

/// <summary>
/// Descripción breve de DAOtienda
/// </summary>
public class DAOtienda
{
    public DAOtienda()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable consultar_login(Elogin sesion)
    {
        DataTable sesiones = new DataTable();

        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_consultar_login", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;            
            dataAdapter.SelectCommand.Parameters.Add("_username", NpgsqlDbType.Varchar).Value = sesion.Username;
            dataAdapter.SelectCommand.Parameters.Add("_password", NpgsqlDbType.Varchar).Value = sesion.Password;

            conectar.Open();
            dataAdapter.Fill(sesiones);
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
        return sesiones;
    }

    public DataTable listar_productos()
    {
        DataTable products = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_productos",conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            conectar.Open();
            dataAdapter.Fill(products);
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
        return products;
    }

    public DataTable listar_carrito(int id)
    {
        DataTable carrito = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_carrito", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_iduser", NpgsqlDbType.Integer).Value = id;
            conectar.Open();
            dataAdapter.Fill(carrito);
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
        return carrito;
    }


    public DataTable terminar_compra(int id)
    {
        DataTable carrito = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_finalizar_compra", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
            conectar.Open();
            dataAdapter.Fill(carrito);
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
        return carrito;
    }

    public DataTable agregar_carrito(int id_usuario, int id_producto )
    {
        DataTable carrito = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_agregar_carrito", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_iduser", NpgsqlDbType.Integer).Value = id_usuario;
            dataAdapter.SelectCommand.Parameters.Add("_idproducto", NpgsqlDbType.Integer).Value = id_producto;
            conectar.Open();
            dataAdapter.Fill(carrito);
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
        return carrito;
    }
}