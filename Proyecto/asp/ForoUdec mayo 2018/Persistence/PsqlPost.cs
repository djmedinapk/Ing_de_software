using Encapsulados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Persistence
{
    public class PsqlPost
    {
        public DataTable ingresar_post(Epublicacion datosPost, int user_id, String Sesion, int modo)
        {
            DataTable categoria = new DataTable();

            if (modo == 1)
            {
                using (ForoUdecEntities1 db = new ForoUdecEntities1())
                {
                    var a = db.f_ingresar_post_privado(Sesion, user_id, datosPost.Nombre, datosPost.Descripcion, datosPost.Categoria, datosPost.Contenido, datosPost.Autor, datosPost.Miniatura, datosPost.Etiquetas).ToList();
                    ConverToDataTable salida = new ConverToDataTable();
                    categoria = salida.ConvertToDataTable(a);
                }
            }
            else
            {
                using (ForoUdecEntities1 db = new ForoUdecEntities1())
                {
                    var a = db.f_ingresar_post(Sesion, user_id, datosPost.Nombre, datosPost.Descripcion, datosPost.Categoria, datosPost.Contenido, datosPost.Autor, datosPost.Miniatura, datosPost.Etiquetas).ToList();
                    ConverToDataTable salida = new ConverToDataTable();
                    categoria = salida.ConvertToDataTable(a);
                }
            }

            return categoria;
        }
        public DataTable eliminar_post(int post_id, String Sesion)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_suspender_post(Sesion, post_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }
        public DataTable cargar_mod_post(Int32 post_id, Int32 user_id)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_cargar_mod_post(user_id, post_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }
        public DataTable validar_post(int post_id, String Sesion)
        {
            DataTable post = new DataTable();


            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_validar_post(Sesion, post_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }

        public DataTable modificar_post(Epublicacion datosPost, int user_id, String Sesion, int post_id)
        {
            DataTable categoria = new DataTable();


            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_modificar_post(Sesion, post_id, user_id, datosPost.Nombre, datosPost.Descripcion, datosPost.Categoria, datosPost.Contenido, datosPost.Autor, datosPost.Miniatura, datosPost.Etiquetas).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                categoria = salida.ConvertToDataTable(a);
            }
            return categoria;
        }




        public DataTable listar_categoria()
        {
            DataTable categoria = new DataTable();


            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_categoria().ToList();
                ConverToDataTable salida = new ConverToDataTable();
                categoria = salida.ConvertToDataTable(a);
            }
            return categoria;
        }


        public DataTable ver_post(int post_id)
        {
            DataTable post = new DataTable();



            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_ver_post2(post_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }
        public DataTable visita_post(int post_id)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {

                var a = db.f_visita_post(post_id);
            }
            return post;
        }
        public DataTable puntuar_post(int puntuacion, int user_id, int post_id)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_puntuar_post(puntuacion, user_id, post_id).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }

        public DataTable comentar_post(int comentario_id, int user_id, int post_id, String comentario)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_comentar_post(comentario_id, user_id, post_id, comentario).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }

        public DataTable listar_post_moderador(String orden)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_post_moderador(orden).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }
        public DataTable ver_post_home(string orden)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_post_home(orden).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }

        public DataTable ver_comentarios(int post_id, int comentario)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_comentarios_post(post_id, comentario).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }

        public DataTable busqueda(String info)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_busqueda(info).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }
        public DataTable ver_post_home_categoria(string orden)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_post_home_categorias(orden).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }

        //-----------------------Post Privado
        public DataTable ver_post_home_private(string orden)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_post_home_private(orden).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }
        public DataTable busqueda_private(String info)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_busqueda_private(info).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }
        public DataTable ver_post_home_categoria_private(string orden)
        {
            DataTable post = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_post_home_categorias_private(orden).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                post = salida.ConvertToDataTable(a);
            }
            return post;
        }
    }
}
