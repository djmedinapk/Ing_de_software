using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Grid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

       protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Resultado = "";
        GridViewRow hola = GridView1.Rows[e.RowIndex];
        int indece = e.RowIndex;
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["id"]);
        
        if ((hola.FindControl("DDL_Marca") as DropDownList).SelectedIndex >= 0)
        {
            (GridView1.Rows[e.RowIndex].FindControl("LabelMarca") as Label).Text = "";
            if ((hola.FindControl("DDL_Ref") as DropDownList).SelectedIndex > 0)
            {
                (GridView1.Rows[e.RowIndex].FindControl("LabelRef") as Label).Text = "";
                EUser1 datos = new EUser1();
                datos.Url = cargarImagen(indece);
                if (datos.Url != "nada")
                {
                    (GridView1.Rows[e.RowIndex].FindControl("LabelFoto") as Label).Text = "";
                   datos.Nombre = (hola.FindControl("TB_Nombre") as TextBox).Text;
                    datos.Apellido = (hola.FindControl("TB_Apellido") as TextBox).Text;
                    datos.Correo = (hola.FindControl("TB_Correo") as TextBox).Text;
                    datos.Contrasena = (hola.FindControl("TB_Contrasena") as TextBox).Text.ToString();
                    datos.Sexo = (hola.FindControl("sexo") as RadioButtonList).SelectedItem.ToString();
                    datos.Marca = (hola.FindControl("DDL_Marca") as DropDownList).SelectedItem.ToString();
                    datos.Referencia = (hola.FindControl("DDL_Ref") as DropDownList).SelectedItem.ToString();
                    datos.Fecha = (hola.FindControl("Calendar1") as Calendar).SelectedDate.ToString();
                    DAOUsuario popo = new DAOUsuario();
                    popo.modificarUsuarios(id,datos);
                    //popo.agregarUsuario(datos);
                    Resultado = "Registro exitoso";
                }
                else { Resultado = "Por favor suba una foto"; }
            }
            else
            {
                (GridView1.Rows[e.RowIndex].FindControl("LabelRef") as Label).Text = "Por favor seleccione una opción";
            }
        }
        else
        {
            (GridView1.Rows[e.RowIndex].FindControl("LabelMarca") as Label).Text = "Por favor seleccione una opción";
        }
        GridView1.EditIndex = -1;

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
    }
    protected String cargarImagen(int indece)
    {
        String url = "";
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName((GridView1.Rows[indece].FindControl("FU_Foto") as FileUpload).PostedFile.FileName);
        string extension = System.IO.Path.GetExtension((GridView1.Rows[indece].FindControl("FU_Foto") as FileUpload).PostedFile.FileName);
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
                (GridView1.Rows[indece].FindControl("FU_Foto") as FileUpload).PostedFile.SaveAs(saveLocation);
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
            }
            catch (Exception exc)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: ');</script>");
            }
            return url;
        }
        else { string nada = ""; return nada; }
    }

    protected void ODSdatos_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }

    protected void ODSdatos_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {

    }
}