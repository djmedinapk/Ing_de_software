using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void B_Completo_Click(object sender, EventArgs e)
    {
        Resultado.Text = "";
        if(DDL_Marca.SelectedIndex >=0 )
        {
            LabelMarca.Text = "";
            if (DDL_Ref.SelectedIndex > 0)
            {
                LabelRef.Text = "";
                EUser1 datos = new EUser1();
                datos.Url = cargarImagen();
                if (datos.Url != "nada")
                {
                    LabelFoto.Text = "";
                    datos.Nombre = TB_Nombre.Text;
                    datos.Apellido = TB_Apellido.Text;
                    datos.Correo = TB_Correo.Text;
                    datos.Contrasena = TB_R_Contrasena.Text.ToString();
                    datos.Sexo = Sexo.SelectedItem.ToString();
                    datos.Marca = DDL_Marca.SelectedItem.ToString();
                    datos.Referencia = DDL_Ref.SelectedItem.ToString();
                    datos.Fecha = Calendar1.SelectedDate.ToString();
                    DAOUsuario user = new DAOUsuario();
                    user.agregarUsuario(datos);
                    Resultado.Text = "Registro exitoso";
                }
                else { LabelFoto.Text = "Por favor suba una foto"; }
            }
            else
            {
                LabelRef.Text = "Por favor seleccione una opción";
            }
        }
        else
        {
            LabelMarca.Text = "Por favor seleccione una opción";
        }
    }

    protected String cargarImagen()
    {
        String url = "";
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName(FU_Foto.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU_Foto.PostedFile.FileName);
        if (nombreArchivo != null)
        {
            string saveLocation = Server.MapPath("~\\Imagenes") + "\\" + nombreArchivo;
            url = "~\\Imagenes" + "\\" + nombreArchivo;
            if (!(extension.Equals(".jpg") || extension.Equals(".gif") || extension.Equals(".jpge") || extension.Equals(".png")))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
            }

            if (System.IO.File.Exists(saveLocation))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
            }

            try
            {
                FU_Foto.PostedFile.SaveAs(saveLocation);
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
            }
            catch (Exception exc)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: ');</script>");
            }
            return url;
        }
        else { string nada = "";return nada; }
    }
}