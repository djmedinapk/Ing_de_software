using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Registro : System.Web.UI.Page
{
    Int32 condicion = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(nombre.Text != String.Empty && username.Text != String.Empty && contraseña.Text != String.Empty && telefono.Text != String.Empty &&
            email.Text != String.Empty)
        {
            Panel2.Visible = true;
        }
        else
        {
            Panel2.Visible = false;
        }
    }
    protected void registrar(object sender, EventArgs e)
    {
        if (nombre.Text !=null && username.Text != null && contraseña.Text != null && telefono.Text != null && 
            email.Text != null )
        {
            Lregistro.ForeColor = System.Drawing.Color.Black;
            Lregistro.Text = "";
            if (contraseña.Text == contraseña2.Text)
            {
                Euser user = new Euser()
                {
                    Nombre = nombre.Text,
                    Username = username.Text,
                    Clave = contraseña.Text,
                    Telefono = telefono.Text,
                    Email = email.Text,
                    Profesion = profesion.SelectedItem.ToString()
                };

                DAOuser daoUser = new DAOuser();
                daoUser.insertarUsuario(user);
                Lregistro.ForeColor = System.Drawing.Color.Green;
                Lregistro.Text = "Registro exitoso";
                Panel2.Visible = true;
                condicion = 1;
                nombre.Enabled = false;
                username.Enabled = false;
                contraseña.Enabled = false;
                contraseña2.Enabled = false;
                telefono.Enabled = false;
                email.Enabled = false;
            }
            else
            {
                Lregistro.ForeColor = System.Drawing.Color.Red;
                Lregistro.Text = "Verifique su clave";

            }
        }
        else
        {
            Lregistro.ForeColor = System.Drawing.Color.Red;
            Lregistro.Text = "Campos vacíos";
        }
    }

    protected void Registrar_estudios(object sender, EventArgs e)
    {
        if (nivel_educativo.SelectedItem.ToString() != null && nombre_instituto.Text != null && ciudad_instituto.Text != null &&
            año_fin.Text != null)
        {
            Lregistro_edu.ForeColor = System.Drawing.Color.Black;
            Lregistro_edu.Text = "";
                Eestudios estudio = new Eestudios()
                {
                    Username = username.Text,
                    Nivel_estudio = nivel_educativo.SelectedItem.ToString(),
                    Nombre_instituto = nombre_instituto.Text,
                    Ciudad_instituto = ciudad_instituto.Text,
                    Año_fin = año_fin.Text,
                };
                DAOestudios daoestudios = new DAOestudios();
                daoestudios.insertar_estudio(estudio);
                Lregistro_edu.ForeColor = System.Drawing.Color.Green;
                Lregistro_edu.Text = "Registro exitoso";
        }
        else
        {
            Lregistro_edu.ForeColor = System.Drawing.Color.Red;
            Lregistro_edu.Text = "Campos vacíos";
        }

    }



    protected void Registrar_empresa(object sender, EventArgs e)
    {
        if (nombre_empresa.Text != null && cargo_empresa.Text != null && tiempo_empresa.Text != null &&
           jefe_empresa.Text != null)
        {
            Lempresa.ForeColor = System.Drawing.Color.Black;
            Lempresa.Text = "";
            Eempresa empresa = new Eempresa()
            {
                Username = username.Text,
                Nombre_empresa = nombre_empresa.Text,
                Cargo_empresa = cargo_empresa.Text,
                Tiempo_empresa = tiempo_empresa.Text,
                Jefe_empresa = jefe_empresa.Text,
            };
            DAOempresa daoempresa = new DAOempresa();
            daoempresa.insertar_empresa(empresa);
            Lempresa.ForeColor = System.Drawing.Color.Green;
            Lempresa.Text = "Registro exitoso";
        }
        else
        {
            Lempresa.ForeColor = System.Drawing.Color.Red;
            Lempresa.Text = "Campos vacíos";
        }
    }

    protected void b_terminar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registro.aspx");
    }

    protected void b_login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}