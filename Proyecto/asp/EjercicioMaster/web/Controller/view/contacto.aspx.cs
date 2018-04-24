using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Data;
using Tilitarios;
using System.Collections;
using Utilitarios;

public partial class view_home_contacto : System.Web.UI.Page
{
    void Page_PreInit(Object sender, EventArgs e)
    {
        Lotros master = new Lotros();
        try {
            this.MasterPageFile = master.aux2((DataRow)Session["data_user"]);
        } catch { }
        
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 2;
        Int32 id_pagina = 5;
        try
        {
            idioma = Int32.Parse(Session["idioma"].ToString());
            Lotros post = new Lotros();
        }
        catch
        {
            idioma = 2;
        }

        Lidioma cargar_controles = new Lidioma();
        Hashtable controles = cargar_controles.cargar_controles(id_pagina, idioma);
        L_contactenos.Text = controles["L_contactenos"].ToString();
        B_contacto.Text = controles["B_contacto"].ToString();

    }

    protected void B_contacto_Click(object sender, EventArgs e)
    {
        Ucontacto contactoa = new Ucontacto();
        contactoa.Nombre = Tcontacto_nombre.Text;
        contactoa.Apellido = Tcontacto_apellido.Text;
        contactoa.Correo = Tcontacto_correo.Text;
        contactoa.Telefono = Tcontacto_telefono.Text;
        contactoa.Contenido = Tcontacto_contenido.Text;

        Lcontacto solicitud = new Lcontacto();
        solicitud.enviarSolicitud(contactoa);
        //Correo correo = new Correo();
        //String mensaje = "<!DOCTYPE html><html><head>	<title>Sin titulo</title></head><body style='font-family: Arial'>	"+
        //    "<div>		<div>			<b>Email: </b> "+contacto.Correo+"		</div>			<div>		"+
        //    "	<h4><b>"+contacto.Nombre+" "+contacto.Apellido+"</b></h4>		</div>		<div>		"+
        //    "	<b>Teléfono: </b>"+contacto.Telefono+"		</div>		<div>		"+
        //    "	<h4><b>Descripción:</b></h4><br>"+contacto.Contenido+"</div>	</div></body></html>";
        //correo.enviarCorreo(contacto.Correo, mensaje);
        Response.Redirect("~/view/home/Index.aspx");
    }
}