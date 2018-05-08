using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LverificarSesion
    {
        public String verificar_sesion(DataRow sesion, String urlerror)
        {
            String respuesta = null;
            if (sesion == null)
            {
                respuesta = urlerror;
            }
            else
            { }
            return respuesta;
        }
        public String verificar_sesion2(DataRow sesion, String urldestino)
        {
            String respuesta = null;
            if (sesion == null)
            { }
            else
            {
                respuesta = urldestino;
            }
            return respuesta;
        }
        public String verificar_permisos(DataRow sesion, String[] permisos, String urlerror)
        {
            String respuesta = null;
            String aux_perm = null;
            if (sesion == null)
            {
                // respuesta = urlerror;
            }
            else
            {
                switch (Int32.Parse(sesion["id_permisos"].ToString()))
                {
                    case 1:
                        aux_perm = "M1";
                        break;
                    case 2:
                        aux_perm = "AD";
                        break;
                    case 3:
                        aux_perm = "U1";
                        break;
                    case 4:
                        aux_perm = "M2";
                        break;
                    case 5:
                        aux_perm = "U2";
                        break;
                    default:
                        aux_perm = null;
                        break;
                }

                respuesta = urlerror;
                foreach (var permiso in permisos)
                {
                    if (aux_perm == permiso)
                    {
                        respuesta = null;
                    }
                }

            }
            return respuesta;
        }
        public bool verificar_permisos_bool(DataRow sesion, String[] permisos, String urlerror)
        {
            bool respuesta = false;
            String aux_perm = null;
            if (sesion == null)
            {
                // respuesta = urlerror;
            }
            else
            {
                switch (Int32.Parse(sesion["id_permisos"].ToString()))
                {
                    case 1:
                        aux_perm = "M1";
                        break;
                    case 2:
                        aux_perm = "AD";
                        break;
                    case 3:
                        aux_perm = "U1";
                        break;
                    case 4:
                        aux_perm = "M2";
                        break;
                    case 5:
                        aux_perm = "U2";
                        break;
                    default:
                        aux_perm = null;
                        break;
                }

                respuesta = false;
                foreach (var permiso in permisos)
                {
                    if (aux_perm == permiso)
                    {
                        respuesta = true;
                    }
                }

            }
            return respuesta;
        }

        public String[] verificar_permisos3(DataRow sesion, String[] permisos, String urlerror,String correo)
        {
            String[] respuesta =new String[2] { null, null };
            String aux_perm = null;
            if (sesion == null)
            {
                // respuesta = urlerror;
            }
            else
            {
                switch (Int32.Parse(sesion["id_permisos"].ToString()))
                {
                    case 1:
                        aux_perm = "M1";
                        break;
                    case 2:
                        aux_perm = "AD";
                        break;
                    case 3:
                        aux_perm = "U1";
                        break;
                    case 4:
                        aux_perm = "M2";
                        break;
                    case 5:
                        aux_perm = "U2";
                        break;
                    default:
                        aux_perm = null;
                        break;
                }

                respuesta[0] = urlerror;
                foreach (var permiso in permisos)
                {
                    if (aux_perm == permiso)
                    {
                        respuesta[0] = null;
                        respuesta[1] = sesion["username"].ToString();
                    }
                }
                if (correo != "")
                {
                    respuesta[0] = null;
                    respuesta[1] = sesion["username"].ToString();
                }

            }
            return respuesta;
        }
    }
}
