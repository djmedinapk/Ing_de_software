using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Reporte_grafico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Lreporte datos = new Lreporte();
        CRSpublicacion.ReportDocument.SetDataSource(datos.llenar_reporte_grafico());
        CRVpublicacion.ReportSource = CRSpublicacion;
    }

    //protected Usuario llenar_reporte()
    //{
    //    Usuario publicaciones = new Usuario();
    //    DAOusuario datos = new DAOusuario();

    //    DataTable datosUsuario = datos.llenar_reporte_publicacion();
    //    DataTable datosFinal = publicaciones.Publicacion;
    //    DataRow fila;


    //    for (int i = 0; i < datosUsuario.Rows.Count; i++)
    //    {
    //        fila = datosFinal.NewRow();

    //        fila["Id"] = int.Parse(datosUsuario.Rows[i]["id"].ToString());
    //        fila["Nombre"] = datosUsuario.Rows[i]["titulo"].ToString();
    //        fila["Visitas"] = int.Parse(datosUsuario.Rows[i]["visitas"].ToString());
    //        fila["Fecha"] = datosUsuario.Rows[i]["fecha"].ToString();
    //        //fila["imagen"] = datosUsuario("ingenieria.png");

    //        datosFinal.Rows.Add(fila);
    //    }

    //    return publicaciones;
    //}
}