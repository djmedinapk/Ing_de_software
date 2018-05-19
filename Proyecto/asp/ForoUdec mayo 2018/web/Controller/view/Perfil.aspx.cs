using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Utilitarios;
using Logica;
using System.Collections;

public partial class view_Perfil : System.Web.UI.Page
{
    //void Page_PreInit(Object sender, EventArgs e)
    //{
    //    String master;
    //    try
    //    {
    //        master = Request.QueryString["m"].ToString();
    //        if (master == "1")
    //        {
    //            this.MasterPageFile = "~/Master1_1.master";
    //        }
    //    }
    //    catch
    //    {

    //    }
    //}
    void Page_PreInit(Object sender, EventArgs e)
    {
        String metodo;
        try
        {
            metodo = Request.QueryString["m"].ToString();
            Lpost validar = new Lpost();
            String[] respuesta = validar.modo(metodo, Session["correo_inst"].ToString(), (DataRow)Session["data_user"]);
            this.MasterPageFile = respuesta[0];
           
        }
        catch
        {
            
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        LverificarSesion verificar = new LverificarSesion();//"U1", "M1", "U2","M2",
        Lotros aux = new Lotros();
        int aux1;
        try
        {
            String url = verificar.verificar_sesion((DataRow)Session["data_user"], "../home/index.aspx");
            Response.Redirect(url);
        }
        catch
        {
            
            try {
                aux1 = Int32.Parse(aux.aux1(IsPostBack));
                BperfilMod_Click(sender, e);
                Iperfil.ImageUrl = Session["Iperfil_url"].ToString();
                Lusername.Text = Session["username"].ToString();
            } catch {

            }

            String[] permisos1 = new String[] { "M1", "M2", "AD" };
            Bmoderador.Visible = false;
            Bmoderador.Visible = verificar.verificar_permisos_bool((DataRow)Session["data_user"], permisos1, "nA");
            String[] permisos2 = new String[] {"AD" };
            Badmin.Visible = false;
            Badmin.Visible = verificar.verificar_permisos_bool((DataRow)Session["data_user"], permisos2, "nA");
        }
        ////String caca = Session["correo_ins"].ToString();
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //if (Session["username"] == null || Session["user_id"] == null)
        //{
        //    Session["username"] = null;
        //    Session["user_id"] = null;
        //    Session["Iperfil_url"] = null;
        //    Response.Redirect("~\\view\\login\\ingresar.aspx");
        //}
        //else
        //{
        //    // TperfilUsuario.Text = Session["username"].ToString();
        //    if (IsPostBack)
        //    {
        //        // BperfilMod_Click(sender, e);
        //        //Iperfil.ImageUrl = Session["Iperfil_url"].ToString();
        //        //Lusername.Text = Session["username"].ToString();
        //    }
        //    else
        //    {
        //        BperfilMod_Click(sender, e);
        //        Iperfil.ImageUrl = Session["Iperfil_url"].ToString();
        //        Lusername.Text = Session["username"].ToString();
        //    }
        //    var papas = (DataRow)Session["data_user"];
        //    if (int.Parse(papas["id_permisos"].ToString()) == 1 || int.Parse(papas["id_permisos"].ToString()) == 4 || int.Parse(papas["id_permisos"].ToString()) == 2)
        //    {
        //        Bmoderador.Visible = true;
        //        if (int.Parse(papas["id_permisos"].ToString()) == 2)
        //        {
        //            Badmin.Visible = true;
        //        }
        //        else
        //        {
        //            Badmin.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        Bmoderador.Visible = false;
        //        Badmin.Visible = false;
        //    }

        //}
        Int32 idioma = 2;
        Int32 id_pagina = 14;
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
        L_total_post.Text = controles["L_total_post"].ToString();
        L_mpublicaciones.Text = controles["L_mpublicaciones"].ToString();
        L_mperfil.Text = controles["L_mperfil"].ToString();
        L_majustes.Text = controles["L_majustes"].ToString();
        Bmoderador.Text = controles["Bmoderador"].ToString();
        Badmin.Text = controles["Badmin"].ToString();
        Blogout.Text = controles["Blogout"].ToString();
        L_foro_publico.Text = controles["L_foro_publico"].ToString();
        L_foro_privado.Text = controles["L_foro_privado"].ToString();
        L_nombre.Text = controles["L_nombre"].ToString();
        TperfilNombre.Attributes["placeholder"] = controles["TperfilNombre"].ToString();
        L_apellido.Text = controles["L_apellido"].ToString();
        TperfilApellido.Attributes["placeholder"] = controles["TperfilApellido"].ToString();
        L_edad.Text = controles["L_edad"].ToString();
        TperfilEdad.Attributes["placeholder"] = controles["TperfilEdad"].ToString();
        L_sexo.Text = controles["L_sexo"].ToString();
        RB1.Text = controles["RB1"].ToString();
        L_usuario.Text = controles["L_usuario"].ToString();
        TperfilAjustesUsername.Attributes["placeholder"] = controles["TperfilAjustesUsername"].ToString();
        L_correo.Text = controles["L_correo"].ToString();
        TperfilAjustesCorreo.Attributes["placeholder"] = controles["TperfilAjustesCorreo"].ToString();
        L_correo_ins.Text = controles["L_correo_ins"].ToString();
        Bcorreoins.Text = controles["Bcorreoins"].ToString();
        L_contrasena.Text = controles["L_contrasena"].ToString();
        TperfilAjustesContrasena.Attributes["placeholder"] = controles["TperfilAjustesContrasena"].ToString();
        TperfilAjustesContrasena2.Attributes["placeholder"] = controles["TperfilAjustesContrasena2"].ToString();
        BajustesGuardar.Text = controles["BajustesGuardar"].ToString();


    }

    protected void Blogout_Click(object sender, EventArgs e)
    {
        
        Llogin user = new Llogin();

        user.terminar_sesion(Session.SessionID.ToString());
        Session["user_id"] = null;
        Session["username"] = null;
        Session["data_user"] = null;
        Session.Clear();
        Response.Redirect("~\\view\\login\\ingresar.aspx");
    }
    protected void BperfilGuardar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        LPerfil perfil = new LPerfil();
        Uadmin_actualizar_usuario2 newData = new Uadmin_actualizar_usuario2();
        //newData.Username = TperfilUsuario.Text;
        // newData.Username = TperfilUsuario.Text;
        //newData.Correo = TperfilCorreo.Text;
        newData.Nombre = TperfilNombre.Text;
        newData.Apellido = TperfilApellido.Text;
        newData.Edad = TperfilEdad.Text;
        newData.Sexo = RB1.SelectedValue;
        String[] url = cargarImagen();
        newData.Avatar = perfil.poner_imagen(url);

        String popup = perfil.modificar_datos_pers(int.Parse(Session["user_id"].ToString()), newData, Session.SessionID); //Envia todos los datos a LOGICA y retorna el mensaje
        Lpopup.Text = popup;
    }

    protected void BperfilMod_Click(object sender, EventArgs e)
    {
        LPerfil traer_datos = new LPerfil();
        Utraer_datos datos = traer_datos.traer_d((DataRow)Session["data_user"]);
        TperfilAjustesUsername.Text = datos.TperfilAjustesUsername;
        TperfilAjustesCorreo.Text = datos.TperfilAjustesCorreo;
        LtotalPublic.Text = datos.LtotalPublic;
        Lpopup.Text = datos.Lpopup;
        TperfilNombre.Text = datos.TperfilNombre;
        TperfilApellido.Text = datos.TperfilApellido;
        TperfilEdad.Text = datos.TperfilEdad;
        IperfilImage.ImageUrl = datos.IperfilImage;
        Session["Iperfil_url"] = datos.IperfilImage;
        RB1.SelectedValue = datos.RB1;
        Bcorreoins.Visible = datos.Bcorreoins;
        Tcorreoins.Visible = datos.Tcorreoins;
        Tcorreoins.Text = datos.Tcorreoins2;
        Session["correo_inst"] = datos.Tcorreoins2;
        Pprivados.Visible = datos.Pprivados;
   

    }


    protected void BajustesGuardar_Click(object sender, EventArgs e)
    {
        Uperfil_campos campos = new Uperfil_campos();

        LPerfil perfil = new LPerfil();

        Uadmin_actualizar_usuario new_login = new Uadmin_actualizar_usuario();

        new_login.Username = TperfilAjustesUsername.Text;
        new_login.Correo = TperfilAjustesCorreo.Text;
        new_login.Password = TperfilAjustesContrasena2.Text;
        campos = perfil.gestionar_nuevos_datos(new_login, int.Parse(Session["user_id"].ToString()), Session.SessionID);  //Envia los datos recibidos en el form, y recibe los campos a colocar

        Lpopup.Text = campos.Popup;
        TperfilAjustesContrasena.Text = campos.Pass1;
        TperfilAjustesContrasena2.Text = campos.Pass2;
        Session["username"] = campos.Username;

        /*else
        {
            DAOperfil ajustes = new DAOperfil();
            DataTable informacion = ajustes.modificar_perfil_ajustes(int.Parse(Session["user_id"].ToString()), Session.SessionID, datosAjustes);
            if (informacion.Rows.Count != 0)
            {
                string frase = informacion.Rows[0][0].ToString();
                Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='../perfil/Perfil.aspx' class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                if(frase== "Cambios Guardados")
                {
                    Session["username"] = datosAjustes.Username;
                }
                
                TperfilAjustesContrasena2.Text = "";
                TperfilAjustesContrasena.Text = "";
                //Response.Redirect("../perfil/Perfil.aspx");
            }
            else
            {


            }
        }*/
    }
    protected void Bcorreoins_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/view/perfil/correoInstitucional.aspx");
    }
    protected String[] cargarImagen()         // Recoge los datos para guardar la imagen del avatar, y si no existe la imagen la guarda
    {
        LPerfil cargar = new LPerfil();
        String[] recibido = new String[2];
        String[] url = new String[3];
        string carpeta_destino = Server.MapPath("~\\Imagenes") + "\\" + Session["user_id"];
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName(FUperfilImagen.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FUperfilImagen.PostedFile.FileName);
        recibido = cargar.generar_url(carpeta_destino, nombreArchivo, extension);  //Recibe la url para guardar el archivo
        url[2] = "~\\Imagenes" + "\\" + Session["user_id"] + "\\" + nombreArchivo;
        try
        {
            FUperfilImagen.PostedFile.SaveAs(recibido[1]);
        }
        catch (Exception exc)
        {
            recibido[0] = "error";
        }
        url[0] = recibido[0];
        url[1] = recibido[1];
        return url;
    }
    protected void Unnamed1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Lpost eliminar = new Lpost();
        String comando = e.CommandName;
        String argumento = e.CommandArgument.ToString();
        eliminar.eliminarPost(Int32.Parse(argumento),comando,Session.SessionID);
        Response.Redirect("Perfil.aspx");
        
    }

    protected void Bmoderador_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\View\\moderador\\moderador.aspx");
    }
    protected void Badmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\View\\admin\\index.aspx");
    }
}