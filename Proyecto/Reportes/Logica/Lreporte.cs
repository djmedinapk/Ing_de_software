using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Logica
{
    public class Lreporte
    {
        public Usuario llenar_reporte_cruzada()
        {
            Usuario usuarioss = new Usuario();
            Dusuario datos = new Dusuario();

            DataTable datosUsuario = datos.llenar_reporte_puntuacion();
            DataTable datosFinal = usuarioss.Puntuacion;
            DataRow fila;


            for (int i = 0; i < datosUsuario.Rows.Count; i++)
            {
                fila = datosFinal.NewRow();

                fila["Id Publicacion"] = int.Parse(datosUsuario.Rows[i]["id_publicacion"].ToString());
                fila["Puntuacion"] = int.Parse(datosUsuario.Rows[i]["puntos"].ToString());
                fila["Id Usuario"] = int.Parse(datosUsuario.Rows[i]["id_usuario"].ToString());
                fila["Username"] = datosUsuario.Rows[i]["username"].ToString();
                //fila["imagen"] = datosUsuario("ingenieria.png");

                datosFinal.Rows.Add(fila);
            }

            return usuarioss;
        }
        public Usuario llenar_reporte_general()
        {
            Usuario usuarioss = new Usuario();
            Dusuario datos = new Dusuario();

            DataTable datosUsuario = datos.llenar_reporte_usuario();
            DataTable datosFinal = usuarioss.Usuarios;
            DataRow fila;


            for (int i = 0; i < datosUsuario.Rows.Count; i++)
            {
                fila = datosFinal.NewRow();

                fila["Id"] = int.Parse(datosUsuario.Rows[i]["id_usuario"].ToString());
                fila["Username"] = datosUsuario.Rows[i]["username"].ToString();
                fila["Correo"] = datosUsuario.Rows[i]["corrreo"].ToString();
                fila["Nombre"] = datosUsuario.Rows[i]["nombre"].ToString();
                fila["Apellido"] = datosUsuario.Rows[i]["apellido"].ToString();
                fila["Edad"] = datosUsuario.Rows[i]["edad"].ToString();
                fila["Sexo"] = datosUsuario.Rows[i]["sexo"].ToString();
                //fila["imagen"] = datosUsuario("ingenieria.png");

                datosFinal.Rows.Add(fila);
            }

            return usuarioss;
        }
        public Usuario llenar_reporte_grafico()
        {
            Usuario publicaciones = new Usuario();
            Dusuario datos = new Dusuario();

            DataTable datosUsuario = datos.llenar_reporte_publicacion();
            DataTable datosFinal = publicaciones.Publicacion;
            DataRow fila;


            for (int i = 0; i < datosUsuario.Rows.Count; i++)
            {
                fila = datosFinal.NewRow();

                fila["Id"] = int.Parse(datosUsuario.Rows[i]["id"].ToString());
                fila["Nombre"] = datosUsuario.Rows[i]["titulo"].ToString();
                fila["Visitas"] = int.Parse(datosUsuario.Rows[i]["visitas"].ToString());
                fila["Fecha"] = datosUsuario.Rows[i]["fecha"].ToString();
                //fila["imagen"] = datosUsuario("ingenieria.png");

                datosFinal.Rows.Add(fila);
            }

            return publicaciones;
        }
    }
}
