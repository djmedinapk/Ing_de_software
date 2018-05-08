using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Logica;
using System.Data;
using Utilitarios;
using Newtonsoft.Json;

namespace wsIonic
{
    /// <summary>
    /// Descripción breve de app
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class app : System.Web.Services.WebService
    {
        public Seguridad.LseguridadServicio SoapHeader;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public String[] AutenticacionUsuario(String username, String password)
        {
            String[] salida = new String[6];
            salida[0] = "-1"; salida[1] = "-1"; salida[2] = "-1"; salida[3] = "-1"; salida[4] = "-1"; salida[5] = "-1";
            try
            {
                if (SoapHeader == null) { salida[4] = "-1"; return salida; }
                if (!SoapHeader.blCredencialesValidas(SoapHeader.stToken,SoapHeader.fuente)) { salida[4] = "-1"; return salida; }
                Lseguridadws validaLogin = new Lseguridadws();
                String[] respuesta = validaLogin.login(username, password);
                
                if (respuesta[4] != "-1")
                {
                    String stToken = Guid.NewGuid().ToString();

                    HttpRuntime.Cache.Add(stToken, SoapHeader.stToken, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(30), System.Web.Caching.CacheItemPriority.NotRemovable, null);

                    salida[0] = respuesta[0]; salida[1] = respuesta[1]; salida[2] = respuesta[2]; salida[3]= respuesta[3]; salida[4] = respuesta[4];
                    salida[5] = stToken;
                    return salida;
                }
                else{
                    salida[0] = respuesta[0]; salida[1] = respuesta[1]; salida[2] = respuesta[2]; salida[3] = respuesta[3]; salida[4] = respuesta[4];
                    return salida;
                }
                
            }
            catch (Exception ex) { throw ex; }
        }
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public DataSet Posts(String orden)
        {
            try
            {
                if (SoapHeader == null) throw new Exception("Requiere Validacion");
                if (!SoapHeader.blCredencialesValidas(SoapHeader)) throw new Exception("Requiere Validacion");

                List<Upost_servicios> Listapost = new List<Upost_servicios>();

                Lservicios datos = new Lservicios();
                DataSet post = datos.post(orden);
                if (post.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < post.Tables[0].Rows.Count; i++)
                    {
                        Upost_servicios aux = new Upost_servicios();
                        aux.Titulo = post.Tables[0].Rows[i][1].ToString();
                        aux.Descripcion = post.Tables[0].Rows[i][2].ToString();
                        aux.Visitas = Int32.Parse(post.Tables[0].Rows[0][4].ToString());
                        //aux.Visitas = id;
                        aux.Fecha = post.Tables[0].Rows[i][5].ToString();
                        Listapost.Add(aux);
                    }

                }
                //JavaScriptSerializer json = new JavaScriptSerializer();
                //String salida=json.Serialize(Listapost);
                //JsonConvert json = new JsonConvert();
                String salida = JsonConvert.SerializeObject(Listapost);
                //Context.Response.Write(salida);
                return post;
            }
            catch { throw new Exception("Error"); }
        }
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public String Contacto(String nombre, String apellido,String correo,String telefono,String contenido)
        {
            try
            {
                if (SoapHeader == null) throw new Exception("Requiere Validacion");
                if (!SoapHeader.blCredencialesValidas(SoapHeader)) throw new Exception("Requiere Validacion");
                Ucontacto contacto = new Ucontacto();
                contacto.Nombre = nombre;
                contacto.Apellido = apellido;
                contacto.Correo = correo;
                contacto.Telefono = telefono;
                contacto.Contenido = contenido;
                Lservicios solicitud = new Lservicios();
                solicitud.enviarSolicitud(contacto);
                return "Recibido Con Exito";
            }
            catch { throw new Exception("Error"); }
        }
    }
}
