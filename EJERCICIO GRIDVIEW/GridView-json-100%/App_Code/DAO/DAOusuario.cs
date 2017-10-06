using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using Npgsql;
using NpgsqlTypes;
using Newtonsoft.Json;

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
    public DataTable insertarjson(String salida)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("sjson.f_insertar_json", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_json", NpgsqlDbType.Varchar).Value = salida;
            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable listar_pais()
    {
        DataTable pais = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("region.f_listar_pais", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;            
            conection.Open();
            dataAdapter.Fill(pais);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return pais;
    }
    public DataTable obtenerDepto(Int32 depto)
    {
        DataTable resDepto = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("region.f_listar_depto", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_depto", NpgsqlDbType.Integer).Value = depto;
            conection.Open();
            dataAdapter.Fill(resDepto);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return resDepto;
    }

    public DataTable listar_datos()
    {
        DataTable datos = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("sjson.f_listar_datos", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            conection.Open();           
            dataAdapter.Fill(datos);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return datos;
    }

    public DataTable ordenar_datos()
    {


        DAOusuario datos = new DAOusuario();
        DataTable items = datos.listar_datos();
        DataTable final = new DataTable();
        final.Columns.Add("id");
        final.Columns.Add("Nombre");
        final.Columns.Add("Apellido");
        final.Columns.Add("Correo");
        final.Columns.Add("Contraseña");
        final.Columns.Add("Pais");
        final.Columns.Add("Departamento");
        final.Columns.Add("Fecha");
        final.Columns.Add("Sexo");
        final.Columns.Add("Url");
        int total = items.Rows.Count;
        for (int i = 0; i < total; i++)
        {

            DataRow a = final.NewRow();
            string rip = items.Rows[i][1].ToString();
            int id = int.Parse(items.Rows[i][0].ToString());
            Euser info = JsonConvert.DeserializeObject<Euser>(rip);
            a["id"] = id;
            a["Nombre"] = info.Nombre;
            a["Apellido"] = info.Apellido;
            a["Correo"] = info.Correo;
            a["Contraseña"] = info.Contrasena;
            a["Pais"] = info.Pais;
            a["Departamento"] = info.Depto;
            a["Fecha"] = info.Fecha;
            a["Sexo"] = info.Sexo;
            a["url"] = info.Url;

            final.Rows.Add(a);
        }
        return final;
    }


    public DataTable eliminar_datos(string Correo)
    {
        DataTable datos = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("sjson.f_eliminar_datos", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar).Value = Correo;
            conection.Open();
            dataAdapter.Fill(datos);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return datos;
    }
    public DataTable modificar_usuario(String salida,String Correo)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("sjson.f_modificar_json", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar).Value = Correo;
            dataAdapter.SelectCommand.Parameters.Add("_json", NpgsqlDbType.Varchar).Value = salida;
            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable prueba(String Nombre, String Apellido, String Correo, String Contraseña)
    {
        DataTable Usuario = new DataTable();
        //NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        //try
        //{
        //    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("sjson.f_modificar_json", conection);
        //    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar).Value = Correo;
        //    dataAdapter.SelectCommand.Parameters.Add("_json", NpgsqlDbType.Varchar).Value = salida;
        //    conection.Open();
        //    dataAdapter.Fill(Usuario);
        //}
        //catch (Exception Ex)
        //{
        //    throw Ex;
        //}
        //finally
        //{
        //    if (conection != null)
        //    {
        //        conection.Close();
        //    }
        //}
        return Usuario;
    }
}