﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using System.Collections;

public partial class view_admin_usuario : System.Web.UI.Page
{
    public Int32 id;
    protected void Page_Load(object sender, EventArgs e)
    {
        LverificarSesion verificar = new LverificarSesion();//"U1", "M1", "U2","M2",
        String[] permisos = new String[] { "AD" };
        try
        {
            String url = verificar.verificar_sesion((DataRow)Session["data_user"],"../home/index.aspx");
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
        Lalert.Text = "";
        Paneldatos.Visible = !IsPostBack;
        PanelUser.Visible = IsPostBack;
        Int32 idioma = 2;
        Int32 id_pagina = 3;
        try
        {
            idioma = Int32.Parse(Session["idioma"].ToString());
            Lotros post = new Lotros();
        }
        catch
        {
            idioma = 2;
        }

        Lidioma cargar_controles = new Lidioma();
        Hashtable controles = cargar_controles.cargar_controles(id_pagina, idioma);
        L_datos_sesion.Text = controles["L_datos_sesion"].ToString();
        BTNactualizarsesion.Text = controles["BTNactualizarsesion"].ToString();
        L_datos_perfil.Text = controles["L_datos_perfil"].ToString();
        RM.Text = controles["RM"].ToString();
        RF.Text = controles["RF"].ToString();
        RO.Text = controles["RO"].ToString();
        BTNactualizarPerfil.Text = controles["BTNactualizarPerfil"].ToString();
        Bvolver.Text = controles["Bvolver"].ToString();
        L_usuarios.Text = controles["L_usuarios"].ToString();
        L_id.Text = controles["L_id"].ToString();
        L_username.Text = controles["L_username"].ToString();
        L_correo.Text = controles["L_correo"].ToString();
        L_estado.Text = controles["L_estado"].ToString();
        L_permisos.Text = controles["L_permisos"].ToString();
        L_action.Text = controles["L_action"].ToString();
        //Bver.Text = controles["Bver"].ToString();
        //Beliminar.Text = controles["Beliminar"].ToString();

    }
    protected void Beliminar_Command(object sender, CommandEventArgs e)
    {
        Int32 id = Int32.Parse(e.CommandArgument.ToString());
        Ladmin_usuario accion = new Ladmin_usuario();

        try {
            Response.Redirect(accion.eliminar_response_redirect(e.CommandName, id, Session.SessionID));//%si comman name es eliminar  hace auto postback y se mantienen el estado de los paneles
        } catch { }

        Paneldatos.Visible = !accion.ver_estado_paneles(e.CommandName);//%si command name es ver entonces es false
        PanelUser.Visible = accion.ver_estado_paneles(e.CommandName);//%si command name es ver entonces es true
        Uadmin_ver_usuario usuario = accion.ver_llenar_campos_usuario(e.CommandName,id);
        Uadmin_ver_usuario_2 usuario2 = accion.ver_llenar_campos_usuario_perfil(e.CommandName, id);
        try
        {
            Tnsesion.Text = usuario.Nsesion;
            Tid.Text = usuario.Id;
            id = Int32.Parse(usuario.Id);
            Tusername.Text = usuario.Username;
            Tmail.Text = usuario.Correo;
            Tpass.Text = usuario.Password;
            Lheader.Text = usuario.Username;
            Lheader2.Text = usuario.Username;
        } catch {
            Lalert.Text = usuario.Alerta;
        }
        try
        {
            Tnombre.Text = usuario2.Nombre;
            Tapellido.Text = usuario2.Apellido;
            Tedad.Text = usuario2.Edad;
            RM.Checked = usuario2.Mas;
            RF.Checked = usuario2.Fem;
            RO.Checked = usuario2.Otro;
        }catch { }
    }
    
    
    protected void Bvolver_Click(object sender, EventArgs e)
    {
        Paneldatos.Visible = true;
        PanelUser.Visible = false;
    }

    protected void BTNactualizarsesion_Click(object sender, EventArgs e)
    { 
        Ladmin_usuario solicitud = new Ladmin_usuario();
        Uadmin_actualizar_usuario registro = new Uadmin_actualizar_usuario();
        id = Int32.Parse(Tid.Text.ToString());
        registro.Username = Tusername.Text.ToString();
        registro.Correo = Tmail.Text.ToString();
        registro.Password = Tpass.Text.ToString();
        registro.Session = Session.SessionID;
        registro.Admin = RBadmin.Checked;
        registro.Nsesion = Tnsesion.Text.ToString();
        solicitud.actualizarsesion(registro, id);
        Response.Redirect("usuario.aspx");

    }
    protected void BTNactualizarPerfil_Click(object sender, EventArgs e)
    {
        Uadmin_ver_usuario_2 datos = new Uadmin_ver_usuario_2();
        datos.Nombre = Tnombre.Text.ToString();
        datos.Apellido = Tapellido.Text.ToString();
        datos.Edad = Tedad.Text.ToString();
        datos.Fem = RF.Checked;
        datos.Mas = RM.Checked;
        datos.Otro = RO.Checked;
        id = Int32.Parse(Tid.Text.ToString());
        Ladmin_usuario solicitud = new Ladmin_usuario();
        solicitud.actualizarPerfil(datos,id,Session.SessionID);
        Response.Redirect("usuario.aspx");
    }
}