using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Descripción breve de Correo
/// </summary>
public class Correo
{
    public Correo()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public void enviarCorreo(String correoDestino, String userToken, String mensaje)
    {

        try
        {
            //Configuración del Mensaje
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
            mail.From = new MailAddress("security@security.com", "Soporte FOROUDEC");

            //Aquí ponemos el asunto del correo
            mail.Subject = "Recuperación Contraseña";
            //Aquí ponemos el mensaje que incluirá el correo
            mail.IsBodyHtml = true;
            mail.Body = mensaje;
            //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
            mail.To.Add(correoDestino);
            //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
            //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));

            //Configuracion del SMTP
            SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
            //Especificamos las credenciales con las que enviaremos el mail
            SmtpServer.Credentials = new System.Net.NetworkCredential("soporte.foroudec@gmail.com", "supportIGS2017");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        catch (Exception ex)
        {

        }
    }
}