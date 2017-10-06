using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_Lista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }





    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string Resultado = "";
        GridViewRow hola = GridView1.Rows[e.RowIndex];
        int indece = e.RowIndex;
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["id"]);
        Euser registro = new Euser();

        registro.Nombre = (hola.FindControl("TNombre") as TextBox).Text;
        registro.Apellido = (hola.FindControl("Tapellido") as TextBox).Text;
        registro.Correo = (hola.FindControl("Tcorreo") as TextBox).Text;
        registro.Contrasena = (hola.FindControl("Tcontraseña") as TextBox).Text;
        registro.Pais = (hola.FindControl("DropDownList1") as DropDownList).SelectedItem.Text.ToString();
        registro.Depto = (hola.FindControl("DropDownList2") as DropDownList).SelectedItem.Text.ToString();
        registro.Fecha = (hola.FindControl("Calendar1") as Calendar).SelectedDate.ToString();
        registro.Sexo = (hola.FindControl("RB1") as RadioButtonList).SelectedValue.ToString();
        registro.Url = cargarImagen(indece);
        if (registro.Url != "nada")
        {
            string output = JsonConvert.SerializeObject(registro);

            DAOusuario json = new DAOusuario();
            json.modificar_usuario(output,registro.Correo);
            //Label1.Text = "Registro existoso";
        }
    }
    protected String cargarImagen(int indece)
    {
        String url = "";
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName((GridView1.Rows[indece].FindControl("FU1") as FileUpload).PostedFile.FileName);
        string extension = System.IO.Path.GetExtension((GridView1.Rows[indece].FindControl("FU1") as FileUpload).PostedFile.FileName);
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
                (GridView1.Rows[indece].FindControl("FU1") as FileUpload).PostedFile.SaveAs(saveLocation);
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
}