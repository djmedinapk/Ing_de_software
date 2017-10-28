using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_login_redirect_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Bredirect_Click(object sender, EventArgs e)
    {
        Response.Redirect("../login/ingresar.aspx");
    }
}