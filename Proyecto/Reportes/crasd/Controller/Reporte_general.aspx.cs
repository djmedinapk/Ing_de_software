using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Reporte_general : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Lreporte datos = new Lreporte();
        CRSusuario.ReportDocument.SetDataSource(datos.llenar_reporte_general());
        CRVusuario.ReportSource = CRSusuario;
    }

    //protected Usuario llenar_reporte()
    //{
    //    Usuario usuarioss = new Usuario();
    //    DAOusuario datos = new DAOusuario();

    //    DataTable datosUsuario = datos.llenar_reporte_usuario();
    //    DataTable datosFinal = usuarioss.Usuarios;
    //    DataRow fila;


    //    for (int i = 0; i < datosUsuario.Rows.Count; i++)
    //    {
    //        fila = datosFinal.NewRow();

    //        fila["Id"] = int.Parse(datosUsuario.Rows[i]["id_usuario"].ToString());
    //        fila["Username"] = datosUsuario.Rows[i]["username"].ToString();
    //        fila["Correo"] = datosUsuario.Rows[i]["corrreo"].ToString();
    //        fila["Nombre"] = datosUsuario.Rows[i]["nombre"].ToString();
    //        fila["Apellido"] = datosUsuario.Rows[i]["apellido"].ToString();
    //        fila["Edad"] = datosUsuario.Rows[i]["edad"].ToString();
    //        fila["Sexo"] = datosUsuario.Rows[i]["sexo"].ToString();
    //        //fila["imagen"] = datosUsuario("ingenieria.png");

    //        datosFinal.Rows.Add(fila);
    //    }

    //    return usuarioss;
    //}
}