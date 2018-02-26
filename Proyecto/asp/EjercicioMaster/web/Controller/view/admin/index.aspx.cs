using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class view_admin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LverificarSesion verificar = new LverificarSesion();//"U1", "M1", "U2","M2",
        String[] permisos = new String[] { "AD" };
        try
        {
            String url = verificar.verificar_sesion((DataRow)Session["data_user"], "../home/index.aspx");
            Response.Redirect(url);
        }
        catch
        {
            try
            {
                String url = verificar.verificar_permisos((DataRow)Session["data_user"], permisos, "../home/index.aspx");
                Response.Redirect(url);
            }
            catch
            {

            }
        }
        Ladmin_main solicitud = new Ladmin_main();
        Uadmin_main datos = new Uadmin_main();
        datos = solicitud.main_page();
        //try {
            LtotalUsers.Text = datos.LtotalUsers;
            HLtotalUser.Attributes.Add("data-content",datos.HltotalUsers);
            LtotalPost.Text = datos.LtotalPost;
            HLtotalPost.Attributes.Add("data-content",datos.HltotalPost);
            LtotalComentarios.Text = datos.LtotalComentarios;
            LtotalPuntos.Text = datos.LtotalPuntos;

        //} catch {
            //Response.Redirect("../home/index.aspx");
       // }
       
    
    }
}