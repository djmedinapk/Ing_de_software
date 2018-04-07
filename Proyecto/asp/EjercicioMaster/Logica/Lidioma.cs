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

namespace Logica
{
    public class Lidioma
    {
        public DataTable cargar_idioma()
        {
            Didioma idiomas = new Didioma();
            DataTable datos = idiomas.cargar_idiomas();
            return datos;
        }
        public DataTable cargar_form()
        {
            Didioma idiomas = new Didioma();
            DataTable datos = idiomas.cargar_form();
            return datos;
        }
        public DataTable cargar_ctrl(Int32 form, Int32 idioma)
        {
            Didioma idiomas = new Didioma();
            DataTable datos = idiomas.cargar_ctrl(form,idioma);
            return datos;
        }

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
        public String agregar_idioma(Uidioma_agregar datos)
        {
            Didioma idi = new Didioma();
            try {
                idi.agregarIdioma(datos.Idioma, datos.Terminacion);
                return "agregado Correctamente";
            } catch { return "error Al agregar Idioma"; }

            
        }
        public void modificar_control(String control,Int32 idioma, Int32 formulario, String texto)
        {
            Didioma idiomas = new Didioma();
            idiomas.guardar_ctrl(control, idioma, formulario, texto);
        }
    }
}
