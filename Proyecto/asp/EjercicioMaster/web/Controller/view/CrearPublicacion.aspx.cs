using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
using System.Collections;

public partial class view_CrearPublicacion : System.Web.UI.Page
{
    String modo;
    void Page_PreInit(Object sender, EventArgs e)
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

        String metodo;
        try
        {
            metodo = Request.QueryString["m"].ToString();
            Lpost validar = new Lpost();
            String[] respuesta= validar.modo(metodo, Session["correo_inst"].ToString(), (DataRow)Session["data_user"]);
            this.MasterPageFile = respuesta[0];
            modo = respuesta[1];
        }
        catch
        {
            modo = "2";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 2;
        Int32 id_pagina = 15;
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
        L_crear_publicacion.Text = controles["L_crear_publicacion"].ToString();
        L_nombre_post.Text = controles["L_nombre_post"].ToString();
        L_descripcion.Text = controles["L_descripcion"].ToString();
        L_categoria.Text = controles["L_categoria"].ToString();
        L_fuentes.Text = controles["L_fuentes"].ToString();
        RBpostfuentes1.Text = controles["RBpostfuentes1"].ToString();
        RBpostfuentes2.Text = controles["RBpostfuentes2"].ToString();
        L_miniatura.Text = controles["L_miniatura"].ToString();
        L_etiquetas.Text = controles["L_etiquetas"].ToString();
        L_etiquetas_Secund.Text = controles["L_etiquetas_Secund"].ToString();
        BcrearpostTerminar.Text = controles["BcrearpostTerminar"].ToString();


    }

    protected void RBpostfuentes2_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected void BcrearpostTerminar_Click(object sender, EventArgs e)
    {
        Lpost publicar = new Lpost();
        Upost post = new Upost();
        post.Nombre = TpostNombre.Text;
        post.Descripcion = Tpostdescripcion.Text;
        post.Contenido = op.Text;
        post.Categoria = int.Parse(DDLcategoria.SelectedItem.Value);
        post.Etiquetas = TpostEtiquetas.Text;
        post.Miniatura = cargarImagen();
        post.Autor=TpostFuentes.Text;
        String respuesta=publicar.publicarPost(post, RBpostfuentes2.Checked,modo,Session.SessionID, Int32.Parse(Session["user_id"].ToString()));
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