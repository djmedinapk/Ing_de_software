using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Reporte_cruzada : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Lreporte datos = new Lreporte();
        CRSpuntuacion.ReportDocument.SetDataSource(datos.llenar_reporte_cruzada());
        CRVpuntuacion.ReportSource = CRSpuntuacion;
    }

    //protected Usuario llenar_reporte()
    //{
    //    Usuario usuarioss = new Usuario();
    //    DAOusuario datos = new DAOusuario();

    //    DataTable datosUsuario = datos.llenar_reporte_puntuacion();
    //    DataTable datosFinal = usuarioss.Puntuacion;
    //    DataRow fila;


    //    for (int i = 0; i < datosUsuario.Rows.Count; i++)
    //    {
    //        fila = datosFinal.NewRow();

    //        fila["Id Publicacion"] = int.Parse(datosUsuario.Rows[i]["id_publicacion"].ToString());
    //        fila["Puntuacion"] = int.Parse(datosUsuario.Rows[i]["puntos"].ToString());
    //        fila["Id Usuario"] = int.Parse(datosUsuario.Rows[i]["id_usuario"].ToString());
    //        fila["Username"] = datosUsuario.Rows[i]["username"].ToString();
    //        //fila["imagen"] = datosUsuario("ingenieria.png");

    //        datosFinal.Rows.Add(fila);
    //    }

    //    return usuarioss;
    //}
}