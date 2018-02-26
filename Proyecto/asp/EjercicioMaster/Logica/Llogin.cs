using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using Encapsulados;
using System.Data;

namespace Logica
{
   public class Llogin
    {
        public DataTable[] Blogin(Uadmin_ver_usuario usuario,String session_id)
        {
           
            Dlogin ingresar = new Dlogin();
            encryption encriptar = new encryption();
            String pass = encriptar.encrypto(usuario.Password);
            DataTable data =ingresar.ingresar(usuario.Username,pass);
            DataTable[] mensaje = new DataTable[2];

            DataTable datos2 = new DataTable();
            datos2.Columns.Add(new DataColumn("correo_ins", System.Type.GetType("System.String")));
            datos2.Columns.Add(new DataColumn("response", System.Type.GetType("System.String")));
            datos2.Columns.Add(new DataColumn("mensaje", System.Type.GetType("System.String")));
            DataRow r1 = datos2.NewRow();

            if (data.Rows.Count > 0)
            {
               
                try
                {
                    String permisos = data.Rows[0]["id_permisos"].ToString();
                    mensaje[0]=data;
                    //mensaje[1] = data.Rows[0]["username"].ToString();
                    //mensaje[2] = data.Rows[0]["id"].ToString();

                    Esesion datosUsuario = new Esesion();
                    // String ipAddress;
                    MAC macc = new MAC();
                    String ipAddress = macc.ip();
                    String MAC = macc.mac();

                    datosUsuario.UserId = int.Parse(mensaje[0].Rows[0]["id"].ToString());
                    datosUsuario.Ip = ipAddress;
                    datosUsuario.Mac = MAC;
                    datosUsuario.Session = session_id;
                    ingresar.guardadoSession(datosUsuario);



                    DcorreoInst old = new DcorreoInst();
                    DataTable correoIns = old.traerCorreoInstitucional(int.Parse(mensaje[0].Rows[0]["id"].ToString()));
                    if (correoIns.Rows.Count > 0)
                    {
                        if (correoIns.Rows[0][0].ToString() != "")
                        {
                            r1["correo_ins"] = correoIns.Rows[0][0].ToString();
                        }
                        else
                        {
                           r1["correo_ins"] = null;
                        }
                    }

                    if (permisos != "2")
                    {
                        r1["response"] = "~/view/perfil/perfil.aspx";
                    }
                    else
                    {
                       r1["response"] = "~/view/admin/index.aspx";
                    }

                }
                catch
                {
                    r1["mensaje"] = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Upssss!</strong> Algo ha salido mal intenta recargar la pagina y vuelve a intentarlo</div>";
                    

                }

            }
            else
            {
               r1["mensaje"] = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>    <span aria-hidden='true'>&times;</span>  </button>  <strong>Datos Incorrectos!</strong> Si has olvidado tus datos has click en Recuperar Contraseña </div>";
               
            }
            
            if (r1["response"].ToString().Length <1)
            {
                r1["response"] =null;
            }
            datos2.Rows.Add(r1);
            mensaje[1] = datos2;
            return mensaje;
        }
        public String validacionurl(String url)
        {
            if (url.Length < 1)
                url = null;
            return url;
        }
        
    }
}
