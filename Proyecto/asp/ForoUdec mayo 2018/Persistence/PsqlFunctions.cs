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
    public class PsqlFunctions
    {
        public DataTable listar_post(int user_id,string sesion)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = from b in db.publicacion
                        join e in db.estado on b.id_estado equals e.id
                        where b.id_estado != 1 && b.id_usuario == user_id && b.seccion == "publico"
                        select new
                        {
                            id = b.id,
                            id_post = "../post/Post.aspx?id=" + b.id.ToString(),
                            titulo = b.titulo,
                            estado = b.descripcion,
                            descripcion = e.tipo,
                            editar_post = "../post/editar-post.aspx?id=" + b.id.ToString()

                        };


                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a.ToList());
            }
            return datos;

        }
        public DataTable listar_categoria()
        {
            DataTable categoria = new DataTable();


            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = from b in db.categoria
                        select b;

                //db.f_listar_categoria().ToList();
                ConverToDataTable salida = new ConverToDataTable();
                categoria = salida.ConvertToDataTable(a.ToList());
            }
            return categoria;
        }

        public DataTable cargar_ctrl(Int32 formulario, Int32 idioma)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = from b in db.lcontroles
                        join d in db.controles

                        on (b.control + b.formulario_id + b.formulario_id + idioma + b.formulario_id).ToString()
                        equals (d.control + d.formulario_id + formulario + d.idioma_id + formulario).ToString()

                        // on b.control.ToString() equals d.control.ToString()
                        where b.formulario_id == formulario
                        orderby b.formulario_id

                        select new
                        {
                            control = b.control,
                            idioma = d.idioma_id,
                            formulario = b.formulario_id,
                            texto = d.texto

                        };


                //db.f_listar_controles(formulario, idioma).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a.ToList());
            }
            return datos;
        }


        public DataTable ActualizarEstado(String user_name)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())

            {
                var a = from b in db.user_session
                        where b.username == user_name
                        select b;

                foreach (user_session b in a) b.estado_session = '2';
                db.SaveChanges();

            }
            return datos;
        }



        //*******************************************************************
        public DataTable caragr_datos_admin_chart()
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                List<f_caragr_datos_admin_chart_Result> ab = new List<f_caragr_datos_admin_chart_Result>();
                f_caragr_datos_admin_chart_Result aa = new f_caragr_datos_admin_chart_Result();
                aa.publicos = db.publicacion.Where(x => x.seccion == "publico").Select(x => x.visitas).Sum();
                aa.privado = db.publicacion.Where(x => x.seccion == "privado").Select(x => x.visitas).Sum();
                ab.Add(aa);
                
                var zb = ab.ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(ab.ToList());
            }

            return datos;
        }

        public DataTable caragr_datos_admin_home()
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                List<f_caragr_datos_admin_home_Result> ab = new List<f_caragr_datos_admin_home_Result>();
                f_caragr_datos_admin_home_Result aa = new f_caragr_datos_admin_home_Result();
                aa.totalusere = db.user_session.Count();
                aa.totalusere1= (from e in db.user_session
                                 join t in db.estado1 on e.id_estado equals t.id
                                 where t.tipo=="Activo"
                                 select e).Count();
                aa.totalusere2= (from e in db.user_session
                                 join t in db.estado1 on e.id_estado equals t.id
                                 where t.tipo == "Inactivo"
                                 select e).Count();
                aa.totalusere3= (from e in db.user_session
                                 join t in db.estado1 on e.id_estado equals t.id
                                 where t.tipo == "Suspendido"
                                 select e).Count();
                aa.totalusere4 = db.publicacion.Count();
                aa.totalusere5 = (from e in db.publicacion
                                  join t in db.estado on e.id_estado equals t.id
                                  where t.tipo == "Activo"
                                  select e).Count();
                aa.totalusere6 = (from e in db.publicacion
                                  join t in db.estado on e.id_estado equals t.id
                                  where t.tipo == "Pendiente"
                                  select e).Count();
                aa.totalusere7 = (from e in db.publicacion
                                  join t in db.estado on e.id_estado equals t.id
                                  where t.tipo == "Suspendido"
                                  select e).Count();
                aa.totalusere8 = db.comentario.Count();
                aa.totalusere9 = db.puntuacion.Select(x => x.puntuacion1).Sum();

                ab.Add(aa);

                var zb = ab.ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(ab.ToList());
            }

            return datos;
        }
        public DataTable f_crud_post(string orden)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                if (orden == "1")
                {
                    var a = from e in db.publicacion
                            join t in db.estado on e.id_estado equals t.id
                            where e.seccion == "privado"
                            select new
                            {
                                id = e.id,
                                id_post = "../private/Post_udec.aspx?id=" + e.id.ToString(),
                                id_post2 = "../post/editar-post.aspx?id=" + e.id.ToString(),
                                titulo = e.titulo,
                                descripcion = e.descripcion,
                                miniatura = t.tipo,
                                visitas = e.visitas,
                                fecha = "Hace" + (e.fecha).ToString() + " Dias"
                            };
                    var az = a.ToList();
                    ConverToDataTable salida = new ConverToDataTable();
                    datos = salida.ConvertToDataTable(a.ToList());

                }
                else
                {
                    var a = from e in db.publicacion
                            join t in db.estado on e.id_estado equals t.id
                            where e.seccion == "publico"
                            select new
                            {
                                id = e.id,
                                id_post = "../POST/Post.aspx?id=" + e.id.ToString(),
                                id_post2 = "../post/editar-post.aspx?id=" + e.id.ToString(),
                                titulo = e.titulo,
                                descripcion = e.descripcion,
                                miniatura = t.tipo,
                                visitas = e.visitas,
                                fecha = "Hace" + (e.fecha).ToString() + " Dias"//fecha = "Hace" + (DateTime.Now.Date - e.fecha.Value.Date).ToString() + " Dias"
                            };



                    var az = a.ToList();
                    ConverToDataTable salida = new ConverToDataTable();
                    datos = salida.ConvertToDataTable(a.ToList());

                }


            }

            return datos;
        }
        public DataTable cargar_usuariospubl()
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = (from e in db.user_session
                          select new
                          {
                              e.username,
                              e.correo,
                              publicaciones = (from z in db.publicacion where z.id_usuario == e.id select z).Count()

                          }
                         ).OrderByDescending(x=>x.publicaciones).Take(5);
                var az = a.ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a.ToList());
            }

            return datos;
        }
        public DataTable f_crud_mod_post (string orden)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                if (orden == "1")
                {
                    var a = from e in db.publicacion
                            join t in db.estado on e.id_estado equals t.id
                            where e.seccion== "privado"
                            select new
                            {
                                id = e.id,
                                id_post = "../private/Post_udec.aspx?id=" + e.id.ToString(),
                                id_post2 = "../post/editar-post.aspx?id=" + e.id.ToString(),
                                titulo = e.titulo,
                                descripcion = e.descripcion,
                                miniatura = t.tipo,
                                visitas = e.visitas,
                                fecha = "Hace"+(e.fecha).ToString() + " Dias"
                            };
                    var az = a.ToList();
                    ConverToDataTable salida = new ConverToDataTable();
                    datos = salida.ConvertToDataTable(a.ToList());

                }
                else
                {
                     var a = from e in db.publicacion
                            join t in db.estado on e.id_estado equals t.id
                            where e.seccion == "publico"
                            select new
                            {
                                id = e.id,
                                id_post = "../POST/Post.aspx?id=" + e.id.ToString(),
                                id_post2 = "../post/editar-post.aspx?id=" + e.id.ToString(),
                                titulo = e.titulo,
                                descripcion = e.descripcion,
                                miniatura = t.tipo,
                                visitas = e.visitas,
                                fecha = "Hace" + (e.fecha).ToString() + " Dias"//fecha = "Hace" + (DateTime.Now.Date - e.fecha.Value.Date).ToString() + " Dias"
                            };


                    
                    var az = a.ToList();
                    ConverToDataTable salida = new ConverToDataTable();
                    datos = salida.ConvertToDataTable(a.ToList());

                }
                
                
            }

            return datos;
        }
        public DataTable busqueda(string parametros)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var ab = (from e in db.publicacion
                          join t in db.categoria on e.id_categoria equals t.id
                          join k in db.estado on e.id_estado equals k.id
                          where k.tipo == "Activo" && e.seccion == "publico" && (e.titulo.Contains(@"/" + parametros + "/") || (e.descripcion.Contains(@"/" + parametros + "/")) || (e.etiquetas.Contains(@"/" + parametros + "/")) || (e.contenido.Contains(@"/" + parametros + "/")))

                          select new
                          {
                              id_post = "../post/Post.aspx?id=" + e.id,
                              titulo = e.titulo,
                              descripcion = e.descripcion,
                              miniatura = e.miniatura,
                              visitas = e.visitas,
                              fecha = e.fecha,
                              id = e.id
                          }).OrderByDescending(x=>x.fecha);


                var zb = ab.ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(ab.ToList());
            }

            
            return datos;
        }

        public DataTable busqueda_private(string parametros)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var ab = (from e in db.publicacion
                          join t in db.categoria on e.id_categoria equals t.id
                          join k in db.estado on e.id_estado equals k.id
                          where k.tipo == "Activo" && e.seccion == "privado" && (e.titulo.Contains(@"/" + parametros + "/") || (e.descripcion.Contains(@"/" + parametros + "/")) || (e.etiquetas.Contains(@"/" + parametros + "/")) || (e.contenido.Contains(@"/" + parametros + "/")))

                          select new
                          {
                              id_post = "../private/Post_udec.aspx?id=" + e.id,
                              titulo = e.titulo,
                              descripcion = e.descripcion,
                              miniatura = e.miniatura,
                              visitas = e.visitas,
                              fecha = e.fecha,
                              id = e.id
                          }).OrderByDescending(x => x.fecha);


                var zb = ab.ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(ab.ToList());
            }


            return datos;
        }

        public DataTable cargar_mod_post(int userid,int postid)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                int aux = (int)db.user_session.Where(z => z.id == userid).Select(x => x.id_permisos).Single();
                if (aux == 2)
                {
                    var ab = from e in db.publicacion
                             where e.id == postid
                             select e;
                    var zba = ab.ToList();
                    ConverToDataTable salida = new ConverToDataTable();
                    datos = salida.ConvertToDataTable(ab.ToList());
                }
                else
                {
                    var ab = from e in db.publicacion
                             where e.id == postid && e.id_usuario==userid
                             select e;
                    var zba = ab.ToList();
                    ConverToDataTable salida = new ConverToDataTable();
                    datos = salida.ConvertToDataTable(ab.ToList());
                }
            }


            return datos;
        }


    }
}
