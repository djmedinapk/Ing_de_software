using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Lotros
    {
        public String aux1(bool postback)
        {
            if (!postback) { return "1"; } else { return "z"; }
        }
        public String aux2(DataRow sesion)
        {
            if (sesion!=null) { return "~/Master2_2.master"; } else { return "~/Master2.master"; }
        }
        public String aux2_privado(DataRow sesion,string correo)
        {
            if (sesion != null) {
                if (correo!= "")
                {
                    return "~/Master1_1.master";
                }
                else {
                    if (Int32.Parse(sesion["id_permisos"].ToString()) == 2)
                    {
                        return "~/Master1_1.master";
                    }
                    else
                    {
                        return "~/Master2.master";
                    }
                }

                
            } else { return "~/Master2.master"; }
        }
    }
}
