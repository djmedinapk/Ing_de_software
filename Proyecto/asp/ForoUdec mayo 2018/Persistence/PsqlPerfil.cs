﻿using Encapsulados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Persistence
{
    public class PsqlPerfil
    {
        public DataTable modificarDatos(int user_id, Eadmin_actualizar_usuario_2 datos, String Sesion)
        {
            DataTable datos1 = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_modificar_usuario(Sesion, user_id,datos.Nombre,datos.Apellido,Int32.Parse(datos.Edad),datos.Sexo,datos.Avatar).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos1 = salida.ConvertToDataTable(a);
            }
            return datos1;
        }

        public DataTable traerDatosSesion(int user_id)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_traer_datos_sesion2(user_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }
                return datos;
        }

        public DataTable modificar_perfil_ajustes(int user_id, String Sesion, Eadmin_actualizar_usuario datos)
        {
            DataTable datos1 = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_modificar_perfil_ajustes(Sesion,user_id,datos.Username,datos.Correo,datos.Password).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos1 = salida.ConvertToDataTable(a);

            }
                    
            return datos1;
        }

        public DataTable traerCorreoInstitucional(int user_id)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_traer_correo_institucional(user_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }
                return datos;
        }

        public DataTable traerDatos(int user_id)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_traer_datos(user_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }


            return datos;
        }

        public DataTable listar_post(int user_id, String Sesion)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_post(Sesion,user_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }


            return datos;
        }

        public DataTable traerDatos_vistaPerfil(int user_id)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_traer_datos_vista_perfil(user_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }

            return datos;
        }

        public DataTable listar_post_public(int user_id, String Sesion)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_post_public(Sesion,user_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }


            return datos;
        }
        public DataTable listar_post_private(int user_id, String Sesion)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_post_private(Sesion, user_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }


            return datos;


        }

        public DataTable RegistrarCorreoInstitucional(int user_id, String correo, String sesion)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_ingresar_correo_institucional(user_id,correo,sesion).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }

            return datos;
        }
    }
}