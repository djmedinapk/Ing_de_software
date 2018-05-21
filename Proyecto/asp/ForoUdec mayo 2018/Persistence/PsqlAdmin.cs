using Encapsulados;
using Utilitarios;
using Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class PsqlAdmin
    {

        public DataTable cargar_pag_home()
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_caragr_datos_admin_home().ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }

        public DataTable suspender_usuario(Int32 id, String Sesion)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_crud_usuarios_delete(id, Sesion).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }


            return datos;
        }

        public DataTable datos_usuario(Int32 id)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_traer_datos_sesion(id.ToString()).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }


            return datos;
        }

        public DataTable datos_usuario_perfil(Int32 id)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_traer_datos_perfil(id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }

            return datos;

        }

        public DataTable actualizar_sesion(int admin, int userid, Eadmin_actualizar_usuario modificados)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_modificar_perfil(admin, modificados.Session, userid, modificados.Username, modificados.Correo, modificados.Password).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }

        public DataTable actualizar_perfil(Eadmin_actualizar_usuario_2 modificados)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_modificar_perfil_usuario(modificados.Session, Int32.Parse(modificados.Id), modificados.Nombre, modificados.Apellido, Int32.Parse(modificados.Edad), modificados.Sexo).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }

        public DataTable cargar_pag_home_toppub()
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_cargar_usuariospubl().ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;

        }

        public DataTable cargar_pag_home_toppoint()
        {
            DataTable datos = new DataTable();

            //using (ForoUdecEntities1 db = new ForoUdecEntities1())
            //{
            //    var a = db.f_cargar_usuariospoints().ToList();
            //    ConverToDataTable salida = new ConverToDataTable();
            //    datos = salida.ConvertToDataTable(a);
            //}


            return datos;
        }

        public DataTable cargar_usuarios()
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_crud_usuarios_listar().ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }

        public DataTable crud_post(String orden)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_crud_post(orden).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);


            }
            return datos;
        }

        public DataTable n_sesiones(String username, Int32 n)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_actualizar_bloqueo_sesiones(username, n);
                ConverToDataTable salida = new ConverToDataTable();

            }

            return datos;

        }

        public DataTable cargar_pag_home_chart()
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_caragr_datos_admin_chart().ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }
            return datos;
        }
    }
}

    