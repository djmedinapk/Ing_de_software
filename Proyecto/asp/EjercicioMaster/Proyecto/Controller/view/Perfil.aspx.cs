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

public partial class view_Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["user_id"] == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;
            Session["Iperfil_url"]=null;
            Response.Redirect("../login/ingresar.aspx");
        }
        else
        {
            // TperfilUsuario.Text = Session["username"].ToString();
            if (IsPostBack)
            {

            }
            else
            {
                BperfilMod_Click(sender, e);                
                Iperfil.ImageUrl= Session["Iperfil_url"].ToString();
                Lusername.Text= Session["username"].ToString();
            }
            
        }
    }

    protected void Blogout_Click(object sender, EventArgs e)
    {
        Session["user_id"] = null;
        Session["username"] = null;

        DAOUsuario user = new DAOUsuario();
        Eusuario datos = new Eusuario
        {
            Session = Session.SessionID
        };
        user.CerrarSession(datos);

        Response.Redirect("../login/ingresar.aspx");
    }
    protected void BperfilGuardar_Click(object sender, EventArgs e)
    {
        DAOperfil news = new DAOperfil();
        EdatosUsuario newData = new EdatosUsuario();

        //newData.Username = TperfilUsuario.Text;
        // newData.Username = TperfilUsuario.Text;
        //newData.Correo = TperfilCorreo.Text;
        newData.Nombre = TperfilNombre.Text;
        newData.Apellido = TperfilApellido.Text;
        newData.Edad = int.Parse(TperfilEdad.Text);
        newData.Sexo = RB1.SelectedValue;
        string url = cargarImagen(); ;
        if (url!= "error") {
            newData.Avatar = url;
        }
        else
        {
            newData.Avatar = "sinActualizar";
        }
        
        news.modificarDatos(int.Parse(Session["user_id"].ToString()),newData);
        Response.Redirect("../perfil/Perfil.aspx");


    }

    protected void BperfilMod_Click(object sender, EventArgs e)
    {
        DAOperfil old = new DAOperfil();
        DataTable datosold = old.traerDatos(int.Parse(Session["user_id"].ToString()));
        DataTable datosSesion = old.traerDatosSesion(int.Parse(Session["user_id"].ToString()));
        if (datosSesion.Rows.Count > 0)
        {
          TperfilAjustesUsername.Text= datosSesion.Rows[0]["username"].ToString();
            TperfilAjustesCorreo.Text= datosSesion.Rows[0]["correo"].ToString();

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
            Session["Iperfil_url"]= datosold.Rows[0]["avatar"].ToString(); ;
            RB1.SelectedValue = datosold.Rows[0]["sexo"].ToString();
        }
        else
        {
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'>      <div class='modal-header'>     <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button>         <h4>Bienvenido A ForoUdec</h4>  </div>      <div class='modal-body'>         <h4>Opciones de Perfil</h4>         Antes de comenzar, te surgerimos que completes tu perfil.      </div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal' class='btn btn-danger'>Cerrar</a>  </div>   </div></div></div>" +
                "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            Session["Iperfil_url"] = "../../Imagenes/Default/123.jpg";
        }
        
    }
    

    protected void BajustesGuardar_Click(object sender, EventArgs e)
    {
        Eregistro datosAjustes = new Eregistro();
        datosAjustes.Username = TperfilAjustesUsername.Text;
        datosAjustes.Correo = TperfilAjustesCorreo.Text;
        datosAjustes.Password = encryption(TperfilAjustesContrasena2.Text);
        DAOperfil ajustes = new DAOperfil();
        DataTable informacion = ajustes.modificar_perfil_ajustes(int.Parse(Session["user_id"].ToString()), Session.SessionID,datosAjustes);
    }
    protected String cargarImagen()
    {
        string carpeta_destino = Server.MapPath("~\\Imagenes") + "\\" + Session["user_id"];
        if (Directory.Exists(carpeta_destino))
        {

        }

        else
        {
            Directory.CreateDirectory(carpeta_destino);
        }


        String url = "";
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName(FUperfilImagen.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FUperfilImagen.PostedFile.FileName);
        if (nombreArchivo != null)
        {
            string saveLocation = Server.MapPath("~\\Imagenes") + "\\" + Session["user_id"] + "\\" + nombreArchivo;

            if (!(extension.Equals(".jpg") || extension.Equals(".gif") || extension.Equals(".jpge") || extension.Equals(".png")))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
                url = "error";
            }
            else
            {

                if (System.IO.File.Exists(saveLocation))
                {
                    //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
                    url = "~\\Imagenes" + "\\" + Session["user_id"] + "\\" + nombreArchivo;
                }
                else
                {

                    try
                    {
                        FUperfilImagen.PostedFile.SaveAs(saveLocation);
                        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
                        url = "~\\Imagenes" + "\\" + Session["user_id"] + "\\" + nombreArchivo;
                    }
                    catch (Exception exc)
                    {
                        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: al cargar la imagen');</script>");
                    }
                }
            }
            return url;
        }
        else { string nada = ""; return nada; }
    }
    public string encryption(String password)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] encrypt;
        UTF8Encoding encode = new UTF8Encoding();
        //encrypt the given password string into Encrypted data  
        encrypt = md5.ComputeHash(encode.GetBytes(password));
        StringBuilder encryptdata = new StringBuilder();
        //Create a new string by using the encrypted data  
        for (int i = 0; i < encrypt.Length; i++)
        {
            encryptdata.Append(encrypt[i].ToString());
        }
        return encryptdata.ToString();
    }
}