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

        string output = JsonConvert.SerializeObject(registro);

        DAOusuario json = new DAOusuario();
        json.insertarjson(output);
        Label1.Text = "Registro existoso";
    }
}