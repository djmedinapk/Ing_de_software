using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["cantidad"] == null && Session["img"] == null && Session["pdf"] == null && Session["offi"] == null)
        {
            Session["cantidad"] = 0;
            Session["img"] = 0;
            Session["pdf"] = 0;
            Session["offi"] = 0;
        }
        DataTable fotos;
        Label5.Text = "img Restrantes: " + (3 - (int)(Session["img"])).ToString();
        Label6.Text = "pdf Restrantes: " + (4 - (int)(Session["pdf"]) ).ToString();
        Label7.Text = "Ofimatica Restrantes: " + (3 - (int)(Session["offi"]) ).ToString();

        if (Session["fotos"] == null)
        {
            fotos = new DataTable();
            fotos.Columns.Add("ruta");
            fotos.Columns.Add("tipo");
            fotos.Columns.Add("url");
            fotos.Columns.Add("nombre");
            Session["fotos"] = fotos;
        }
        else
        {
            fotos = (DataTable)Session["fotos"];
        }

        GridView1.DataSource = fotos;
        GridView1.DataBind();

    }
    protected void B_Cargar_Click(object sender, EventArgs e)
    {
        Int32 cant, img, pdf, offi;
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName(FU_Cliente.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU_Cliente.PostedFile.FileName);
        
        
        //Insercion de archivo a carpeta temp
        string saveLocation = Server.MapPath("~\\Archivos\\temp") + "\\" +"temp_" + nombreArchivo;
        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
            return;
        }
        try
        {
            FU_Cliente.PostedFile.SaveAs(saveLocation);
            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo temporal ha sido cargado');</script>");
        }
        catch (Exception exc)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: ');</script>");
            return;
        }

        //Evaluacion del tipo de archivo y su respectivo proceso de guardado de temp a carpeta final
        switch (extension)
        {
            case ".jpg": case ".gif": case ".jpge": case ".png":
                cant = int.Parse(Session["cantidad"].ToString());
                if (cant < 10) //Igual nunca llega a superar 10 archivos por las otras verificaciones
                {
                    img = int.Parse(Session["img"].ToString());
                    if (img < 3)
                    {
                        string saveLocation_final = Server.MapPath("~\\Archivos\\imagenes") + "\\" + "img_" + nombreArchivo;
                        if (System.IO.File.Exists(saveLocation_final))
                        {
                            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
                            try
                            {
                                System.IO.File.Delete(saveLocation);
                            }
                            catch
                            {

                            }
                            return;
                        }
                        try
                        {
                            System.IO.File.Move(saveLocation, saveLocation_final);
                            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
                            //System.IO.File.Delete(saveLocation_final); 
                            
                                        DataTable fotos = new DataTable();

                                        fotos = (DataTable)Session["fotos"];

                                        string[] celdas = new string[4];

                                        celdas[0] = "..\\Archivos\\imagenes\\" + "img_" + nombreArchivo;
                                        celdas[1] = extension;
                                        celdas[2] = saveLocation_final; 
                                        celdas[3] = nombreArchivo;



                            fotos.Rows.Add(celdas);

                                        Session["fotos"] = fotos;

                                        GridView1.DataSource = fotos;
                                        GridView1.DataBind();
                        }
                        catch (Exception exc)
                        {
                            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: ');</script>");
                            try
                            {
                                System.IO.File.Delete(saveLocation);
                            }
                            catch
                            {

                            }
                            return;
                        }
                        cant++;
                        Session["cantidad"] = cant;
                       
                        img++;
                        Session["img"] = img;
                    }
                    else
                    {
                        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No puede ingresar mas imagenes');</script>");
                        System.IO.File.Delete(saveLocation);
                        return;
                    }
                }
                else
                {
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No se pueden ingresar mas archivos');</script>");
                    System.IO.File.Delete(saveLocation);
                    return;
                }
                break;


            case ".pdf":
                cant = int.Parse(Session["cantidad"].ToString());
                if (cant < 10)
                {
                    pdf = int.Parse(Session["pdf"].ToString());
                    if (pdf < 4)
                    {
                        string saveLocation_final = Server.MapPath("~\\Archivos\\pdf") + "\\" + "pdf_" + nombreArchivo;
                        if (System.IO.File.Exists(saveLocation_final))
                        {
                            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
                            try{
                                System.IO.File.Delete(saveLocation);
                            }
                            catch
                            {

                            }
                            return;
                        }
                        try
                        {
                            System.IO.File.Move(saveLocation, saveLocation_final);
                            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
                            //System.IO.File.Delete(saveLocation_final);
                            DataTable fotos = new DataTable();

                            fotos = (DataTable)Session["fotos"];

                            string[] celdas = new string[4];

                            celdas[0] = "..\\recursos\\pdf.jpg";
                            celdas[1] = extension;
                            celdas[2] = saveLocation_final;
                            celdas[3] = nombreArchivo;


                            fotos.Rows.Add(celdas);

                            Session["fotos"] = fotos;

                            GridView1.DataSource = fotos;
                            GridView1.DataBind();
                        }
                        catch (Exception exc)
                        {
                            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: ');</script>");
                            try
                            {
                                System.IO.File.Delete(saveLocation);
                            }
                            catch
                            {

                            }
                            return;
                        }
                        
                        cant++;
                        Session["cantidad"] = cant;
                        
                        pdf++;
                        Session["pdf"] = pdf;
                    }
                    else
                    {
                        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No puede ingresar mas archivos de tipo pdf');</script>");
                        System.IO.File.Delete(saveLocation);
                        return;
                    }
                }
                else
                {
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No se pueden ingresar mas archivos');</script>");
                    System.IO.File.Delete(saveLocation);
                    return;
                }
                break;
            case ".docx":
            case ".doc":
            case ".xls":
            case ".xlsx":
            case ".pptx":
            case ".ppt":
            case ".txt":
            case ".mdb":
            case ".pps":
            case ".pub":
            case ".one":
                cant = int.Parse(Session["cantidad"].ToString());
                if (cant < 10)
                {
                    offi = int.Parse(Session["offi"].ToString());
                    if (offi < 3)
                    {
                        string saveLocation_final = Server.MapPath("~\\Archivos\\ofimatica") + "\\" + "ofimatica_" + nombreArchivo;
                        if (System.IO.File.Exists(saveLocation_final))
                        {
                            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
                            try
                            {
                                System.IO.File.Delete(saveLocation);
                            }
                            catch
                            {

                            }
                            return;
                        }
                        try
                        {
                            System.IO.File.Move(saveLocation, saveLocation_final);
                            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
                            //System.IO.File.Delete(saveLocation_final);
                            DataTable fotos = new DataTable();

                            fotos = (DataTable)Session["fotos"];

                            string[] celdas = new string[4];

                            celdas[0] = "..\\recursos\\"+extension+".jpg";
                            celdas[1] = extension;
                            celdas[2] = saveLocation_final;
                            celdas[3] = nombreArchivo;


                            fotos.Rows.Add(celdas);

                            Session["fotos"] = fotos;

                            GridView1.DataSource = fotos;
                            GridView1.DataBind();
                        }
                        catch (Exception exc)
                        {
                            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: ');</script>");
                            try
                            {
                                System.IO.File.Delete(saveLocation);
                            }
                            catch
                            {

                            }
                            return;
                        }
                        
                        cant++;
                        Session["offi"] = cant;
                        
                        offi++;
                        Session["offi"] = offi;
                    }
                    else
                    {
                        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No puede ingresar mas archivos de ofimatica');</script>");
                        System.IO.File.Delete(saveLocation);
                        return;
                    }
                }
                else
                {
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No se pueden ingresar mas archivos');</script>");
                    System.IO.File.Delete(saveLocation);
                    return;
                }
                break;

                
        }

        Label5.Text = "img Restrantes: " + (3 - (int)(Session["img"])).ToString();
        Label6.Text = "pdf Restrantes: " + (4 - (int)(Session["pdf"])).ToString();
        Label7.Text = "Ofimatica Restrantes: " + (3 - (int)(Session["offi"])).ToString();





        /*DataTable fotos = new DataTable();

        fotos = (DataTable)Session["fotos"];

        string[] celdas = new string[2];

        celdas[0] = "~\\Archivos\\Imagenes" + "\\" + "hola_" + nombreArchivo;
        celdas[1] = nombreArchivo;


        fotos.Rows.Add(celdas);

        Session["fotos"] = fotos;

        GridView1.DataSource = fotos;
        GridView1.DataBind();*/
    }
}