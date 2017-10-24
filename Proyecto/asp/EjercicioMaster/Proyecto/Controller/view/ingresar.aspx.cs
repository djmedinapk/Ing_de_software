using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_login_ingresar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["username"]==null || Session["user_id"] == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;

        }
        else
        {
            Response.Redirect("../perfil/perfil.aspx");
        }
        
    }


    protected void Bregistro_Click(object sender, EventArgs e)
    {
        Eregistro usuario = new Eregistro();
        usuario.Correo = TregistroCorreo.Text;
        usuario.Username = TregistroUser.Text;
        usuario.Password = encryption(TregistroPassword2.Text);
        DAOregistro registro = new DAOregistro();
        DataTable informacion = registro.registro(usuario);
        if (informacion.Rows.Count != 0)
        {
            string frase = informacion.Rows[0][0].ToString();
            if (frase == "Registro_exitoso") {
                string mensaje = "<div class='alert alert-success alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Registro Exitoso!</strong> Gracias Por Ser Parte De Esta Gran Comunidad</div>";
                LMensaje.Text = mensaje;
                TloginUser.Text = usuario.Correo;
                TloginPassword.Focus();
            }else
            {
                string mensaje = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Ya se Encuentra en uso este correo  y/o nombre de Usuario!</strong> Si has olvidado tus datos has click en Recuperar Contraseña</div>";
                LMensaje.Text = mensaje;
            }
            
        }
        else
        {

            string mensaje = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Upssss!</strong> Algo ha salido mal intenta recargar la pagina y vuelve a intentarlo</div>";
            LMensaje.Text = mensaje;
        }
        
    }

    protected void Blogin_Click(object sender, EventArgs e)
    {
        DAOUsuario guardarUsuario = new DAOUsuario();
        string username= TloginUser.Text.ToString();
        string pass= encryption(TloginPassword.Text.ToString());
        System.Data.DataTable data = guardarUsuario.ingresar(username,pass);


        if (int.Parse(data.Rows[0]["user_id"].ToString()) > 0)
        {
            try
            {
                Session["username"] = data.Rows[0]["username"].ToString();
                Session["user_id"] = data.Rows[0]["user_id"].ToString();

                Eusuario datosUsuario = new Eusuario();
                // String ipAddress;
                MAC macc;


                // ipAddress = HttpContext.Current.Request.UserHostAddress;

                macc = new MAC();
                String ipAddress = macc.ip();
                String MAC = macc.mac();

                datosUsuario.UserId = int.Parse(Session["user_id"].ToString());
                datosUsuario.Ip = ipAddress;
                datosUsuario.Mac = MAC;
                datosUsuario.Session = Session.SessionID;


                guardarUsuario.guardadoSession(datosUsuario);

                Response.Redirect("../perfil/perfil.aspx");
            }
            catch {
                string mensaje = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Upssss!</strong> Algo ha salido mal intenta recargar la pagina y vuelve a intentarlo</div>";
                LMensaje.Text = mensaje;

            }

        }
        else
        {
            string mensaje = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Datos Incorrectos!</strong> Si has olvidado tus datos has click en Recuperar Contraseña </div>";
            LMensaje.Text = mensaje;
        }

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
}