﻿using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class view_post_editar_post : System.Web.UI.Page
{
    String POST;
    protected void Page_Load(object sender, EventArgs e)
    {
        String urlerror = "../login/ingresar.aspx";
        LverificarSesion verificar = new LverificarSesion();//"U1", "M1", "U2","M2",
        String[] permisos = new String[] { "AD", "U1", "M1", "U2", "M2" };
        try
        {
            String url = verificar.verificar_sesion((DataRow)Session["data_user"], urlerror);
            Response.Redirect(url);
        }
        catch
        {
            try
            {
                String url = verificar.verificar_permisos((DataRow)Session["data_user"], permisos, urlerror);
                Response.Redirect(url);
            }
            catch
            {

            }
        }
        try
        {
            POST = Request.QueryString[0].ToString();
            try
            {
                Lotros aux = new Lotros();
                Int32 aux1;
                aux1= Int32.Parse(aux.aux1(IsPostBack).ToString());
                cargar_datos(sender, e);
            }
            catch{  }
        }
        catch { }
            
            
        
    }
    protected void RBpostfuentes2_CheckedChanged(object sender, EventArgs e)
    {
    }
    protected void cargar_datos(object sender, EventArgs e)
    {
        Lpost cargar = new Lpost();
        Int32 post_id = Int32.Parse(POST);
        Int32 user_id =Int32.Parse( Session["user_id"].ToString());
        Upost2 datos = new Upost2();
        datos  = cargar.cargarPost(post_id,user_id);
        TpostNombre.Text = datos.Nombre;
        Tpostdescripcion.Text = datos.Descripcion;
        TpostEtiquetas.Text = datos.Etiquetas;
        contenidoedito.Text = datos.Contenido;
        RBpostfuentes1.Checked = datos.Fuentes1;
        RBpostfuentes2.Checked = datos.Fuentes2;
        TpostFuentes.Text = datos.Autor;
        Iminiaturapost.ImageUrl = datos.Miniatura;
        DDLcategoria.SelectedValue = datos.Categoria;
        
        
    }

    protected void BcrearpostTerminar_Click(object sender, EventArgs e)
    {
        DAOpost publicar = new DAOpost();
        Upost post = new Upost();
        Lpost modificar = new Lpost();
        post.Nombre = TpostNombre.Text;
        post.Descripcion = Tpostdescripcion.Text;
        post.Contenido = op.Text;
        post.Categoria = int.Parse(DDLcategoria.SelectedItem.Value);
        post.Etiquetas = TpostEtiquetas.Text;
        post.Miniatura = cargarImagen();
        post.Autor = TpostFuentes.Text;
        String respuesta = modificar.terminar_mod(post, Session.SessionID, int.Parse(Session["user_id"].ToString()), int.Parse(POST), RBpostfuentes2.Checked, Iminiaturapost.ImageUrl.ToString());
        Lpopup.Text = respuesta;
        Response.Redirect("../perfil/perfil.aspx");
    }
    protected String cargarImagen()
    {
        Lpost post = new Lpost();
        ClientScriptManager cm = this.ClientScript;
        String nombreArchivo = System.IO.Path.GetFileName(FUminiatura.PostedFile.FileName);
        String extension = System.IO.Path.GetExtension(FUminiatura.PostedFile.FileName);
        String sesion = Session["user_id"].ToString();
        String tpostnombre = TpostNombre.Text.ToString();
        String carpeta_destino = Server.MapPath("~\\Imagenes\\Post") + "\\" + sesion + "\\" + tpostnombre;
        String saveLocation = carpeta_destino + "\\" + nombreArchivo;

        String[] url = post.cargar_Imagen(nombreArchivo,sesion,tpostnombre,extension,carpeta_destino,saveLocation);

        try
        {
            FUminiatura.PostedFile.SaveAs(url[1]);
        }
        catch
        {

        }
        return url[0];
    }
}