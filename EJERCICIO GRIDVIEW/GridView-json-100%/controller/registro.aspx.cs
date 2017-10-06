using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Benviar_Click(object sender, EventArgs e)
    {
       
        Euser registro = new Euser();

        registro.Nombre= Tnombre.Text;
        registro.Apellido= Tapellido.Text;
        registro.Correo = Tcorreo.Text;
        registro.Contrasena = Tcontraseña2.Text;
        registro.Pais = DropDownList1.SelectedItem.Text.ToString();
        registro.Depto = DropDownList2.SelectedItem.Text.ToString();
        registro.Fecha = Calendar1.SelectedDate.ToString();
        registro.Sexo = RB1.SelectedValue.ToString();
        registro.Acept = CB2.Checked;
        registro.Info = CB1.Checked;
        registro.Url= cargarImagen();
        if (registro.Url != "nada")
        {
            string output = JsonConvert.SerializeObject(registro);

            DAOusuario json = new DAOusuario();
            json.insertarjson(output);
            Label1.Text = "Registro existoso";
        }
    }

    protected String cargarImagen()
    {
        String url = "";
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName(FU1.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU1.PostedFile.FileName);
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
                FU1.PostedFile.SaveAs(saveLocation);
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