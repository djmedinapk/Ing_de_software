using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_admin_usuario : System.Web.UI.Page
{
    public Int32 id;
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
                id= Int32.Parse(dato.Rows[0]["id"].ToString());
                Tusername.Text = dato.Rows[0]["username"].ToString();
                Tmail.Text = dato.Rows[0]["correo"].ToString();
                Tpass.Text = dato.Rows[0]["pasword"].ToString();
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

    protected void BTNactualizarsesion_Click(object sender, EventArgs e)
    {
        int serAdmin;
        DAOadmin datos = new DAOadmin();
        Eregistro registro = new Eregistro();
        id = Int32.Parse(Tid.Text.ToString());
        registro.Username = Tusername.Text.ToString();
        registro.Correo = Tmail.Text.ToString();
        registro.Password = encryption(Tpass.Text.ToString());
        registro.Session = Session.SessionID;
        if (RBadmin.Checked)
        {
             serAdmin = 1;
        }
        else
        {
             serAdmin = 0;
        }
        DataTable dato = datos.actualizar_sesion(serAdmin,id, registro);
        Response.Redirect("usuario.aspx");
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

    protected void BTNactualizarPerfil_Click(object sender, EventArgs e)
    {
        EdatosUsuario datos = new EdatosUsuario();
        DAOadmin mod = new DAOadmin();
        datos.Nombre = Tnombre.Text.ToString();
        datos.Apellido = Tapellido.Text.ToString();
        datos.Edad = int.Parse(Tedad.Text.ToString());
        String sesion = Session.SessionID;
        id = Int32.Parse(Tid.Text.ToString());
        if (RM.Checked)
        {
            datos.Sexo = RM.Text;
        }
        else
        {
            if (RF.Checked)
            {
                datos.Sexo = RF.Text;
            }
            else
            {
                datos.Sexo = RO.Text;
            }
        }
        DataTable dato = mod.actualizar_perfil(datos, sesion,id);
        Response.Redirect("usuario.aspx");

    }
}