using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            Blogin.Visible = false;
            
            LUsername.Text = (String)Session["username_usuario"];
            Bcarrito_terminar_compra.Visible = true;
            Lcarrito_login.Visible = false;
            Bcarrito_login.Visible = false;
            Bsalir.Visible = true;
        }
        else
        {
            Blogin.Visible = true;
            LUsername.Visible = false;
            Bsalir.Visible = false;
            Bcarrito_terminar_compra.Visible = false;
            Lcarrito_login.Visible = true;
            Bcarrito_login.Visible = true;
        }
    }



    protected void Button2_Click(object sender, EventArgs e)
    {

        Response.Redirect("Login.aspx");
    }

    protected void Bcarrito_login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void Bcarrito_terminar_compra_Click(object sender, EventArgs e)
    {
        int id = (int)Session["idusuario"];
        DAOtienda terminar_compra = new DAOtienda();
        DataTable informacion = terminar_compra.terminar_compra(id);
        Response.Redirect("home.aspx");
    }
   
    public void DataList1_ItemCommand(object source,
System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if(Session["usuario"] != null)
        {
            if (e.CommandName == "agregar")
            {

                Label lbl = e.Item.FindControl("Lid") as Label;
                int id = int.Parse(lbl.Text);
                TextBox TCantidad = e.Item.FindControl("TextBox1") as TextBox;
                int cantidadd = int.Parse(TCantidad.Text);
                DAOtienda consultar_cantidad = new DAOtienda();
                DataTable cons_cantidad = consultar_cantidad.consultar_cantidad(id);

                DataRow inven = cons_cantidad.Rows[0];
                int inventario = (int)inven["cantidad"];
                if (cantidadd <= inventario)
                {
                    DAOtienda agregar_carrito = new DAOtienda();
                    int id1 = (int)Session["idusuario"];
                    DataTable agregar = agregar_carrito.agregar_carrito(id1, id,cantidadd);
                    Response.Redirect("home.aspx");
                }
                else {

                    Label tryr = e.Item.FindControl("Label4") as Label;
                    tryr.Text="El maximo de productos disponibles es "+inventario;
                    
                }
                   
                    
            }
        }
        else {
            Response.Redirect("login.aspx");
        }
        

    }


    protected void Bsalir_Click(object sender, EventArgs e)
    {
        Session["usuario"] = null;
        Session["idusuario"] = null;
        Session["username_usuario"] = null;
        Session["nombre_usuario"] = null;
        Response.Redirect("home.aspx");

    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    { 
    }
}