using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_admin_usuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Lalert.Text = "";
        if (!IsPostBack)
        {
            Paneldatos.Visible = true;
            PanelUser.Visible = false;
        }
        
    }
    protected void Beliminar_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "eliminar")
        {
            Int32 id = Int32.Parse(e.CommandArgument.ToString());
            DAOadmin eliminar = new DAOadmin();
            DataTable informacion = eliminar.suspender_usuario(id, Session.SessionID);
            Response.Redirect("usuario.aspx");
        }
        if (e.CommandName == "ver")
        {
            Int32 id = Int32.Parse(e.CommandArgument.ToString());
            DAOadmin datos = new DAOadmin();
            DataTable dato = datos.datos_usuario(id);
            Paneldatos.Visible = false;
            PanelUser.Visible = true;
            if (dato.Rows.Count > 0)
            {
                //Lalert.Text = Alerta("id"+ dato.Rows[0]["id"].ToString(), "rojo");
                Tid.Text = dato.Rows[0]["id"].ToString();
                Tusername.Text = dato.Rows[0]["username"].ToString();
                Tmail.Text = dato.Rows[0]["correo"].ToString();
                Lheader.Text= dato.Rows[0]["username"].ToString();
                Lheader2.Text = dato.Rows[0]["username"].ToString();
            }
            else
            {
                Lalert.Text = Alerta("No Se Encontro EL usuario","rojo");
            }
            DataTable dato2 = datos.datos_usuario_perfil(id);
            if (dato2.Rows.Count > 0)
            {
                //Lalert.Text = Alerta("id" + dato2.Rows[0]["nombre"].ToString(), "rojo");
                Tnombre.Text = dato2.Rows[0]["nombre"].ToString();
                Tapellido.Text = dato2.Rows[0]["apellido"].ToString();
                Tedad.Text = dato2.Rows[0]["edad"].ToString();
                switch (dato2.Rows[0]["sexo"].ToString()) {
                    case "Masculino":
                        RM.Checked = true;
                        break;
                    case "Femenino":
                        RF.Checked = true;
                        break;
                    case "Otro":
                        RO.Checked = true;
                        break;
                    default:
                        RO.Checked = true;
                        break;
                }
            }
            else
            {
                //Lalert.Text = Alerta("El usuario No tiene datos de perfil ", "amarillo");
            }
        }
    }
    private String Alerta(String mensaje, String tipo) {
        String boton;
        String aux="dark";
        switch (tipo) {
            case "amarillo":
                aux = "warning";
                break;
            case "verde":
                aux = "success";
                break;
            case "azul":
                aux = "primary";
                break;
            case "gris":
                aux = "dark";
                break;
            case "rojo":
                aux = "danger";
                break;
        }
        boton= "<div class='alert alert-"+aux+" alert-dismissible show' role='alert'>" +mensaje+
            "  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>" +
            "    <span aria-hidden='true'>&times;</span>" +
            "  </button>" +
            "</div> ";
        return boton;
    }
    
    protected void Bvolver_Click(object sender, EventArgs e)
    {
        Paneldatos.Visible = true;
        PanelUser.Visible = false;
    }
}