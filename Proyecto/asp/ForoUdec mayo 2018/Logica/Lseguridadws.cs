using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Lseguridadws
    {
        public bool validartoken(string token, String fuente)
        {
            if (!String.IsNullOrEmpty(token) && !String.IsNullOrEmpty(fuente))
            {
                Dservicios solicitud = new Dservicios();
                DataTable respuesta = solicitud.validarToken(token, fuente);
                if (respuesta.Rows.Count > 0)
                {
                    if (respuesta.Rows[0][0].ToString() == "true")
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        public String[] login(String username, String password)
        {
            String[] result = new String[5];

            Dservicios ingresar = new Dservicios();
            encryption encriptar = new encryption();
            String pass = encriptar.encrypto(password);
            DataTable data = ingresar.login(username, pass);


            if (data.Rows.Count > 0)
            {

                try
                {
                    //ingresar.limpiar_bloqueo_sesion(usuario.Username);

                    result[0] = data.Rows[0]["username"].ToString();
                    result[1] = data.Rows[0]["id"].ToString();
                    result[2] = data.Rows[0]["id_permisos"].ToString();
                    result[3] = "Login Exitoso";
                    result[4] = "1";
                    //Esesion datosUsuario = new Esesion();
                    //// String ipAddress;
                    //MAC macc = new MAC();
                    //String ipAddress = macc.ip();
                    //String MAC = macc.mac();

                    //datosUsuario.UserId = int.Parse(mensaje[0].Rows[0]["id"].ToString());
                    //datosUsuario.Ip = ipAddress;
                    //datosUsuario.Mac = MAC;
                    //datosUsuario.Session = session_id;
                    //ingresar.guardadoSession(datosUsuario);



                    //DcorreoInst old = new DcorreoInst();
                    //DataTable correoIns = old.traerCorreoInstitucional(int.Parse(mensaje[0].Rows[0]["id"].ToString()));
                    //if (correoIns.Rows.Count > 0)
                    //{
                    //    if (correoIns.Rows[0][0].ToString() != "")
                    //    {
                    //        r1["correo_ins"] = correoIns.Rows[0][0].ToString();
                    //    }
                    //    else
                    //    {
                    //        r1["correo_ins"] = null;
                    //    }
                    //}

                    //if (permisos != "2")
                    //{
                    //    r1["response"] = "~/view/perfil/perfil.aspx";
                    //}
                    //else
                    //{
                    //    r1["response"] = "~/view/admin/index.aspx";
                    //}

                }
                catch
                {
                    result[0] = username;
                    result[1] = password;
                    result[2] = "-1";
                    result[3] = "Error Al Procesar La Solicitud";
                    result[4] = "-1";


                }
            }
            else
            {
                result[0] = "-1";
                result[1] = "-1";
                result[2] = "-1";
                result[3] = "Datos de Sesion Invalidos";
                result[4] = "-1";
            }
            return result;
        }
    }
}
