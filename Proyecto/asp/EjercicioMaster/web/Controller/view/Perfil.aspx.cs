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
        //String caca = Session["correo_ins"].ToString();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (Session["username"] == null || Session["user_id"] == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;
            Session["Iperfil_url"] = null;
            Response.Redirect("~\\view\\login\\ingresar.aspx");
        }
        else
        {
            // TperfilUsuario.Text = Session["username"].ToString();
            if (IsPostBack)
            {
                // BperfilMod_Click(sender, e);
                //Iperfil.ImageUrl = Session["Iperfil_url"].ToString();
                //Lusername.Text = Session["username"].ToString();
            }
            else
            {
                BperfilMod_Click(sender, e);
                Iperfil.ImageUrl = Session["Iperfil_url"].ToString();
                Lusername.Text = Session["username"].ToString();
            }
            var papas = (DataRow)Session["data_user"];
            if (int.Parse(papas["id_permisos"].ToString()) == 1 || int.Parse(papas["id_permisos"].ToString()) == 4 || int.Parse(papas["id_permisos"].ToString()) == 2)
            {
                Bmoderador.Visible = true;
                if (int.Parse(papas["id_permisos"].ToString()) == 2)
                {
                    Badmin.Visible = true;
                }
                else
                {
                    Badmin.Visible = false;
                }
            }
            else
            {
                Bmoderador.Visible = false;
                Badmin.Visible = false;
            }

        }
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
        DAOperfil old = new DAOperfil();
        DataTable datosold = old.traerDatos(int.Parse(Session["user_id"].ToString()));
        DataTable datosSession = old.traerDatosSesion(int.Parse(Session["user_id"].ToString()));
        DataTable correoIns = old.traerCorreoInstitucional(int.Parse(Session["user_id"].ToString()));

        if (datosSession.Rows.Count > 0)
        {
            TperfilAjustesUsername.Text = datosSession.Rows[0]["username"].ToString();
            TperfilAjustesCorreo.Text = datosSession.Rows[0]["correo"].ToString();
            LtotalPublic.Text = datosSession.Rows[0]["posts"].ToString();



        }
        if (datosold.Rows.Count > 0)
        {
            Lpopup.Text = "";
            //TperfilUsuario.Text = datosold.Rows[0]["username"].ToString();
            //TperfilCorreo.Text = datosold.Rows[0]["corrreo"].ToString();
            TperfilNombre.Text = datosold.Rows[0]["nombre"].ToString();
            TperfilApellido.Text = datosold.Rows[0]["apellido"].ToString();
            TperfilEdad.Text = datosold.Rows[0]["edad"].ToString();
            IperfilImage.ImageUrl = datosold.Rows[0]["avatar"].ToString();
            Session["Iperfil_url"] = datosold.Rows[0]["avatar"].ToString(); ;
            RB1.SelectedValue = datosold.Rows[0]["sexo"].ToString();
        }
        else
        {
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'>      <div class='modal-header'>     <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button>         <h4>Bienvenido A ForoUdec</h4>  </div>      <div class='modal-body'>         <h4>Opciones de Perfil</h4>         Antes de comenzar, te surgerimos que completes tu perfil.      </div>      <div class='modal-footer'>     <a href='#v-pills-profile' data-dismiss='modal' data-toggle='pill'  role='tab' aria-controls='v-pills-profile'  class='btn btn-danger'>Ir a Perfil</a>  </div>   </div></div></div>" +
                "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            Session["Iperfil_url"] = "~\\Imagenes\\Default\\123.jpg";
        }
        if (correoIns.Rows.Count > 0)
        {
            if (correoIns.Rows[0][0].ToString() != "")
            {

                Bcorreoins.Visible = false;
                Tcorreoins.Visible = true;
                Tcorreoins.Text = correoIns.Rows[0][0].ToString();
                Session["correo_inst"] = correoIns.Rows[0][0].ToString();
                Pprivados.Visible = true;
            }
            else
            {
                Pprivados.Visible = false;
                Bcorreoins.Visible = true;
                Tcorreoins.Visible = false;
                Tcorreoins.Text = "";
            }
        }
        else
        {
            Pprivados.Visible = false;
            Bcorreoins.Visible = true;
            Tcorreoins.Visible = false;
            Tcorreoins.Text = "";
        }

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