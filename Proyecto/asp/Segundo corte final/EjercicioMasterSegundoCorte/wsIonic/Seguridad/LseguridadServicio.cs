using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logica;

namespace wsIonic.Seguridad
{
    public class LseguridadServicio : System.Web.Services.Protocols.SoapHeader
    {
        public String stToken { get; set; }
        public String fuente { get; set; }
        public String AutenticacionToken { get; set; }

        public bool blCredencialesValidas(String stToken,String fuente)
        {
            try
            {
                Lseguridadws validar = new Lseguridadws();
                bool respuesta = validar.validartoken(stToken, fuente);
                if (respuesta) { return true; }
                else { return false; }

            }
            catch (Exception ex) { throw ex; }
        }

        public bool blCredencialesValidas(LseguridadServicio SoapHeader)
        {
            try
            {
                if (SoapHeader == null)
                {
                    return false;
                }
                if (!String.IsNullOrEmpty(SoapHeader.AutenticacionToken))
                {
                    return (HttpRuntime.Cache[SoapHeader.AutenticacionToken] != null);

                }
                return false;
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
