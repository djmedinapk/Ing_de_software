using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Logica
{
    public class Ladmin_post
    {
        public DataTable listar_crud_post(String orden)
        {
            Dadmin post = new Dadmin();
            DataTable publicaciones = post.crud_post(orden);
            return publicaciones;
        }
    }
}
