using Datos;
using Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Lservicios
    {
        public DataSet post(String orden)
        {

            Dservicios solicitud = new Dservicios();
            //PsqlServicios solicitud = new PsqlServicios();
            DataSet datos = solicitud.ver_post_home_categoria(orden);
            return datos;
        }
    }
}
