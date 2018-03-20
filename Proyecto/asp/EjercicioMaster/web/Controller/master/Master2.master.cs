using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.Collections;

public partial class Master1 : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 2;
        Int32 id_pagina = 23;
        try
        {
             idioma = Int32.Parse(Session["idioma"].ToString());
            Lotros post = new Lotros();
            try
            {
                Int32 aux=Int32.Parse(post.aux1(!IsPostBack));
            }
            catch {
                DDL_lenguaje.SelectedValue= idioma.ToString();
            }
            
        }
        catch
        {
             idioma = 2;
        }
        
        Lidioma cargar_controles = new Lidioma();
        Hashtable controles = cargar_controles.cargar_controles(id_pagina, idioma);
        L_lenguaje.Text = controles["L_lenguaje"].ToString();
        B_entrar.Text = controles["B_entrar"].ToString();
        L_bienvenido.Text = controles["L_bienvenido"].ToString();
        L_inicio.Text = controles["L_inicio"].ToString();
        L_categorias.Text = controles["L_categorias"].ToString();
        L_contacto.Text = controles["L_contacto"].ToString();
        BTNsearch.Text = controles["BTNsearch"].ToString();
        L_inicio1.Text = controles["L_inicio1"].ToString();
        L_categoarias1.Text = controles["L_categoarias1"].ToString();
        L_contacto2.Text = controles["L_contacto2"].ToString();
        L_registarse1.Text = controles["L_registarse1"].ToString();
        BTNsearch2.Text = controles["BTNsearch2"].ToString();
        L_contacto1.Text = controles["L_contacto1"].ToString();
        L_derechos_reservados.Text = controles["L_derechos_reservados"].ToString();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //DAOUsuario guardarUsuario = new DAOUsuario();
        //string username = Tlogin_user.Text.ToString();
        //string pass = encryption(Tlogin_pass.Text.ToString());
        //System.Data.DataTable data = guardarUsuario.ingresar(username, pass);


        //if (int.Parse(data.Rows[0]["user_id"].ToString()) > 0)
        //{
        //    try
        //    {
        //        Session["username"] = data.Rows[0]["username"].ToString();
        //        Session["user_id"] = data.Rows[0]["user_id"].ToString();

        //        Eusuario datosUsuario = new Eusuario();
        //        // String ipAddress;
        //        MAC macc;


        //        // ipAddress = HttpContext.Current.Request.UserHostAddress;

        //        macc = new MAC();
        //        String ipAddress = macc.ip();
        //        String MAC = macc.mac();

        //        datosUsuario.UserId = int.Parse(Session["user_id"].ToString());
        //        datosUsuario.Ip = ipAddress;
        //        datosUsuario.Mac = MAC;
        //        datosUsuario.Session = Session.SessionID;


        //        guardarUsuario.guardadoSession(datosUsuario);

        //        Response.Redirect("../perfil/perfil.aspx");
        //    }
        //    catch
        //    {
        //        string mensaje = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Upssss!</strong> Algo ha salido mal intenta recargar la pagina y vuelve a intentarlo</div>";
        //        // LMensaje.Text = mensaje;

        //    }

        //}
        //else
        //{
        //    string mensaje = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Datos Incorrectos!</strong> Si has olvidado tus datos has click en Recuperar Contraseña </div>";
        //    // LMensaje.Text = mensaje;
        //}

        Response.Redirect("~/view/login/ingresar.aspx");
    }
    //public string encryption(String password)
    //{
    //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
    //    byte[] encrypt;
    //    UTF8Encoding encode = new UTF8Encoding();
    //    //encrypt the given password string into Encrypted data  
    //    encrypt = md5.ComputeHash(encode.GetBytes(password));
    //    StringBuilder encryptdata = new StringBuilder();
    //    //Create a new string by using the encrypted data  
    //    for (int i = 0; i < encrypt.Length; i++)
    //    {
    //        encryptdata.Append(encrypt[i].ToString());
    //    }
    //    return encryptdata.ToString();
    //}

    protected void Bminiatura_salir_Click(object sender, EventArgs e)
    {
        Llogin user = new Llogin();

        user.terminar_sesion(Session.SessionID.ToString());
        Session["user_id"] = null;
        Session["username"] = null;
        Session["data_user"] = null;
        Session.Clear();
        Response.Redirect("~\\view\\login\\ingresar.aspx");
    }

    protected void Bminiatura_settings_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/view/perfil/perfil.aspx");
    }

    protected void BTNsearch_Click(object sender, EventArgs e)
    {
        String busqueda=Tsearch.Text;
        Response.Redirect("~/view/home/search.aspx?search=" + busqueda);
    }
    protected void BTNsearch2_Click(object sender, EventArgs e)
    {
        String busqueda = Tsearch2.Text;
        Response.Redirect("~/view/home/search.aspx?search=" + busqueda);
    }

    protected void DDL_lenguaje_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 index = Int32.Parse(DDL_lenguaje.SelectedValue.ToString());
        Lidioma cambiar_cultura = new Lidioma();
        String cultura=cambiar_cultura.select_idioma(index);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultura);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
        Session["idioma"] = index;
        Int32 id_pagina = 23;
        try
        {
            Lidioma cargar_controles = new Lidioma();
            Hashtable controles = cargar_controles.cargar_controles(id_pagina, index);
            L_lenguaje.Text = controles["L_lenguaje"].ToString();
            B_entrar.Text = controles["B_entrar"].ToString();
            L_bienvenido.Text = controles["L_bienvenido"].ToString();
            L_inicio.Text = controles["L_inicio"].ToString();
            L_categorias.Text = controles["L_categorias"].ToString();
            L_contacto.Text = controles["L_contacto"].ToString();
            BTNsearch.Text = controles["BTNsearch"].ToString();
            L_inicio1.Text = controles["L_inicio1"].ToString();
            L_categoarias1.Text = controles["L_categoarias1"].ToString();
            L_contacto2.Text = controles["L_contacto2"].ToString();
            L_registarse1.Text = controles["L_registarse1"].ToString();
            BTNsearch2.Text = controles["BTNsearch2"].ToString();
            L_contacto1.Text = controles["L_contacto1"].ToString();
            L_derechos_reservados.Text = controles["L_derechos_reservados"].ToString();
            //webBrowser1.Refresh();
        }
        catch
        {
            
        }

        
    }
}
