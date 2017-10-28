using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_CrearPublicacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string scrip = " < script language=\"JavaScript\">";
        //scrip += "CKEDITOR.replace('editor1');";
        //scrip += "</ script >";
        //Leditor.Text = scrip; 
        //string script = "<script language=\"JavaScript\">";
        //script += "alert(\"Hola Mundo\");";
        //script += "CKEDITOR.replace('editor1');";
        //script += "</script>";
        //Leditor.Text = script;
        if (Session["username"] == null || Session["user_id"] == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;
            Response.Redirect("../login/ingresar.aspx");
        }
        else
        {
            //.Text = Session["username"].ToString();
        }
    }

    protected void RBpostfuentes2_CheckedChanged(object sender, EventArgs e)
    {
        //if (RBpostfuentes2.Checked==true)
        //{
        //    TpostFuentes.Enabled = true;
        //}
        //else
        //{
        //    TpostFuentes.Enabled = false;
        //}
    }

    protected void BcrearpostTerminar_Click(object sender, EventArgs e)
    {
        DAOpost publicar = new DAOpost();
        Epost post = new Epost();
        post.Nombre = TpostNombre.Text;
        post.Descripcion = Tpostdescripcion.Text;
        post.Contenido = op.Text;
        post.Categoria = int.Parse(DDLcategoria.SelectedItem.Value);
        post.Etiquetas = TpostEtiquetas.Text;
        post.Miniatura = cargarImagen();
        post.Autor = TpostFuentes.Text;
       DataTable informacion = publicar.ingresar_post(post, int.Parse(Session["user_id"].ToString()), Session.SessionID);

        if (informacion.Rows.Count != 0)
        {
            string frase = informacion.Rows[0][0].ToString();
            if (frase == "Registro_exitoso")
            {
                string mensaje = "<div class='alert alert-success alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Registro Exitoso!</strong> Gracias Por Ser Parte De Esta Gran Comunidad</div>";
                
            }
            else
            {
                string mensaje = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Ya se Encuentra en uso este correo  y/o nombre de Usuario!</strong> Si has olvidado tus datos has click en Recuperar Contraseña</div>";
                
            }

        }
        else
        {

            string mensaje = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Upssss!</strong> Algo ha salido mal intenta recargar la pagina y vuelve a intentarlo</div>";
            
        }
        Response.Redirect("../perfil/perfil.aspx");
    }
    protected String cargarImagen()
    {
        string carpeta_destino = Server.MapPath("~\\Imagenes\\Post") + "\\" + Session["user_id"]+ "\\"+ TpostNombre.Text;
        if (Directory.Exists(carpeta_destino))
        {

        }

        else
        {
            Directory.CreateDirectory(carpeta_destino);
        }


        String url = "";
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName(FUminiatura.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FUminiatura.PostedFile.FileName);
        if (nombreArchivo != null)
        {
            string saveLocation = Server.MapPath("~\\Imagenes\\Post") + "\\" + Session["user_id"] + "\\" + TpostNombre.Text + "\\" + nombreArchivo;

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
                    url = "~\\Imagenes\\Post" + "\\" + Session["user_id"] + "\\" + TpostNombre.Text + "\\" + nombreArchivo;
                }
                else
                {

                    try
                    {
                        FUminiatura.PostedFile.SaveAs(saveLocation);
                        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
                        url = "~\\Imagenes\\Post" + "\\" + Session["user_id"]+"\\" + TpostNombre.Text + "\\" + nombreArchivo;
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
}