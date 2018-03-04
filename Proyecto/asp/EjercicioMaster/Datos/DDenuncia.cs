﻿using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DDenuncia
    {
        public DataTable aceptar_denuncia_comentario(int id_denuncia)
        {
            DataTable respuesta = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("denuncia.f_aceptar_denuncia_comentario", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_denunciaid", NpgsqlDbType.Integer).Value = id_denuncia;
                conectar.Open();
                dataAdapter.Fill(respuesta);
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
            return respuesta;
        }

        public DataTable denuncia_publicacion(int user_id, int publicacion_id, String descripcion)
        {
            DataTable respuesta = new DataTable();

            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("denuncia.f_denunciar_publicacion", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_userid", NpgsqlDbType.Integer).Value = user_id;
                dataAdapter.SelectCommand.Parameters.Add("_postid", NpgsqlDbType.Integer).Value = publicacion_id;
                dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Text).Value = descripcion;

                conectar.Open();
                dataAdapter.Fill(respuesta);
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
            return respuesta;
        }


    }

}
