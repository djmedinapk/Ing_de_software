using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using System.Threading;
using System.Globalization;
using System.Collections;
using Utilitarios;
using Persistencia;
using Tablas;

namespace Logica
{
    public class Lidioma
    {
        public DataTable cargar_idioma()
        {
            //Didioma idiomas = new Didioma();
            //DataTable datos = idiomas.cargar_idiomas();
            Pidioma solicitud = new Pidioma();
            List<idioma> datos = solicitud.cargarIdioma();
            ConverToDataTable op = new ConverToDataTable();
            DataTable result = op.ConvertToDataTable(datos);
            return result;
        }
        public DataTable cargar_form()
        {
            //Didioma idiomas = new Didioma();
            //DataTable datos = idiomas.cargar_form();
            //return datos;

            Pidioma solicitud = new Pidioma();
            List<formulario> datos = solicitud.cargarForm();

            ConverToDataTable op = new ConverToDataTable();
            DataTable result = op.ConvertToDataTable(datos);
            return result;

        }
        public String agregar_idioma(Uidioma_agregar datos)
        {
            //Didioma idi = new Didioma();
            //try {
            //    idi.agregarIdioma(datos.Idioma, datos.Terminacion);
            //    return "agregado Correctamente";
            //} catch { return "error Al agregar Idioma"; }
            try
            {
                idioma neww = new idioma();
                neww.nombre = datos.Idioma;
                neww.terminacion = datos.Terminacion;

                Pidioma solicitud = new Pidioma();
                solicitud.agregarIdioma(neww);

                return "agregado Correctamente";

            }
            catch { return "error Al agregar Idioma"; }
        }
        public String eliminar_idioma(Int32 id)
        {
            //Didioma idi = new Didioma();
            //try {
            //    idi.agregarIdioma(datos.Idioma, datos.Terminacion);
            //    return "agregado Correctamente";
            //} catch { return "error Al agregar Idioma"; }
            try
            {
                Pidioma solicitud = new Pidioma();
                solicitud.eliminarIdioma(id);
                return "Eliminado Correctamente";
            }
            catch { return "error Al Eliminar Idioma"; }
        }

//------------------Fin  Entity.persistence--------------------------------
        

        public String select_idioma(Int32 idioma)
        {
            String cultura="es-CO";
            Didioma idioam = new Didioma();
            DataTable datos = idioam.cargar_idiomas();
            if (datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    if (Int32.Parse(datos.Rows[i][0].ToString())==idioma)
                    {
                        cultura = datos.Rows[i][2].ToString();
                    }
                }
            }
            return cultura;
            
        }

        public Hashtable cargar_controles(Int32 formulario_id,Int32 idioma_id)
        {
            Didioma idioma = new Didioma();
            DataTable info = idioma.obtenerIdioma(formulario_id,idioma_id);

            Hashtable controles = new Hashtable();

            for (int i = 0; i < info.Rows.Count; i++)
            {
                controles.Add(info.Rows[i]["control"].ToString(), info.Rows[i]["valor"].ToString());
            }
            return controles;
        }
        
        public void modificar_control(String control,Int32 idioma, Int32 formulario, String texto)
        {
            Didioma idiomas = new Didioma();
            controle neww = new controle();
            neww.control = control;
            neww.formulario_id = formulario;
            neww.idioma_id = idioma;
            neww.texto = texto;
            //Pidioma solicitud = new Pidioma();
            //solicitud.agregarIdiomaControl(neww);
            idiomas.guardar_ctrl(control, idioma, formulario, texto);
        }
        public DataTable cargar_ctrl(Int32 form, Int32 idioma)
        {
            Didioma idiomas = new Didioma();
            DataTable datos = idiomas.cargar_ctrl(form, idioma);
            return datos;
        }
    }
}
