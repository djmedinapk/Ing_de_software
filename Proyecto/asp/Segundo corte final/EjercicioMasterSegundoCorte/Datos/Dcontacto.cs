using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encapsulados;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Data;

namespace Datos
{
    public class Dcontacto
    {
        public DataTable Enviar_solicitud(Econtacto solicitud)
        {
            DataTable contraseña = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_agregar_contacto", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar).Value = solicitud.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar).Value = solicitud.Apellido;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar).Value = solicitud.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Varchar).Value = solicitud.Telefono;
                dataAdapter.SelectCommand.Parameters.Add("_contenido", NpgsqlDbType.Text).Value = solicitud.Contenido;
                conection.Open();
                dataAdapter.Fill(contraseña);
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
            return contraseña;
        }
    }
}
