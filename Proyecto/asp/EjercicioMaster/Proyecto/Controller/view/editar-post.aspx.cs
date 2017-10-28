using System;
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

public partial class view_post_editar_post : System.Web.UI.Page
{
    String POST;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["user_id"] == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;
            Response.Redirect("../login/ingresar.aspx");
        }
        else
        {
            POST = Request.QueryString[0].ToString();
            if (!IsPostBack)
            {
                
                cargar_datos(sender, e);
            }
            
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
    protected void cargar_datos(object sender, EventArgs e)
    {
        DAOpost cargar = new DAOpost();
        Int32 post_id = Int32.Parse(POST);
        Int32 user_id =Int32.Parse( Session["user_id"].ToString());
        DataTable datos_post = cargar.cargar_mod_post(post_id,user_id);
        if (datos_post.Rows.Count > 0)
        {
            TpostNombre.Text = datos_post.Rows[0]["titulo"].ToString();
            Tpostdescripcion.Text = datos_post.Rows[0]["descripcion"].ToString();
            TpostEtiquetas.Text = datos_post.Rows[0]["etiquetas"].ToString();
            contenidoedito.Text= datos_post.Rows[0]["contenido"].ToString();
            if (datos_post.Rows[0]["fuente"].ToString() == "El Contenido es de mi autoria y/o Recopilacion de varias fuentes")
            {
                RBpostfuentes1.Checked = true;
            }
            else
            {
                RBpostfuentes2.Checked = true;
                TpostFuentes.Text = datos_post.Rows[0]["fuente"].ToString();
            }
            Iminiaturapost.ImageUrl = datos_post.Rows[0]["miniatura"].ToString();
            //editor1.Value= datos_post.Rows[0]["contenido"].ToString();
            DDLcategoria.SelectedValue= datos_post.Rows[0]["id_categoria"].ToString();
        }
        
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

        if (post.Miniatura == "error")
        {
            post.Miniatura = Iminiaturapost.ImageUrl.ToString();
        }
        

        if (RBpostfuentes2.Checked == true)
        {
            post.Autor = TpostFuentes.Text;
        }
        else
        {
            post.Autor = "El Contenido es de mi autoria y/o Recopilacion de varias fuentes";
        }

        DataTable informacion = publicar.modificar_post(post, int.Parse(Session["user_id"].ToString()), Session.SessionID,int.Parse(POST));

        if (informacion.Rows.Count != 0)
        {
            string frase = informacion.Rows[0][0].ToString();
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
               "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});"+
                       "setInterval('guardar()', 1500);" +
                       "function guardar() { window.location.href='" + "Post.aspx?id=" + POST.ToString() + "'; }</script>";


            //Response.Redirect("../perfil/Perfil.aspx");
        }
        else
        {


        }
        //Response.Redirect("../perfil/perfil.aspx");
    }
    protected String cargarImagen()
    {
        string carpeta_destino = Server.MapPath("~\\Imagenes\\Post") + "\\" + Session["user_id"] + "\\" + TpostNombre.Text;
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
        if (nombreArchivo != "")
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
                        url = "~\\Imagenes\\Post" + "\\" + Session["user_id"] + "\\" + TpostNombre.Text + "\\" + nombreArchivo;
                    }
                    catch (Exception exc)
                    {
                        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: al cargar la imagen');</script>");
                    }
                }
            }
            return url;
        }
        else { string nada = "error"; return nada; }
    }
}