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
    String modo;
    void Page_PreInit(Object sender, EventArgs e)
    {
        String metodo;
        try
        {
            metodo = Request.QueryString["m"].ToString();
            if (metodo == "1")
            {
                this.MasterPageFile = "~/Master1_1.master";
                modo = "1";
            }else { modo = "2"; }
        }
        catch
        {
            modo = "2";
        }
    }
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
        //if (RBpostfuentes2.Checked == true)
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
        if (RBpostfuentes2.Checked == true)
        {
            post.Autor = TpostFuentes.Text;
        }
        else
        {
            post.Autor = "El Contenido es de mi autoria y/o Recopilacion de varias fuentes";
        }
        DataTable informacion = null; ;
        if (modo == "1")
        {
            informacion = publicar.ingresar_post(post, int.Parse(Session["user_id"].ToString()), Session.SessionID,1);
        }
        else
        {
            informacion = publicar.ingresar_post(post, int.Parse(Session["user_id"].ToString()), Session.SessionID,0);
        }

         

        if (informacion.Rows.Count != 0)
        {
            string frase = informacion.Rows[0][0].ToString();
            if (frase == "Ingreso_exitoso")
            {
                string mensaje = "<strong>Se relizo la publicacion</strong>, espera a que un moderador la acepte";
                Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                      "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                      "setInterval('guardar()', 1500);" +
                      "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";

            }
            else
            {
                string mensaje = "Error al prrocesar la solicitud";
                Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                      "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                      "setInterval('guardar()', 1500);" +
                       "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";
            }

        }
        else
        {

            string mensaje = "<strong>Upssss!</strong> Algo ha salido mal intenta recargar la pagina y vuelve a intentarlo";
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                      "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                      "setInterval('guardar()', 1500);" +
                       "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";
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
               // cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
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
                        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: al cargar la imagen');</script>");
                    }
                }
            }
            return url;
        }
        else { string nada = ""; return nada; }
    }
}