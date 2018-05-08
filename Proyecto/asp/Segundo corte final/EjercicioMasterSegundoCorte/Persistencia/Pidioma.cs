using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tablas;

namespace Persistencia
{
    public class Pidioma
    {

        public List<idioma> cargarIdioma()
        {
            List<idioma> datos = new List<idioma>();
            using (ForoUdecContext db = new ForoUdecContext("idioma"))
            {
                datos = db.idiomas.ToList();
            }
            return datos;

        }
        public List<formulario> cargarForm()
        {
            List<formulario> datos = new List<formulario>();
            using (ForoUdecContext db = new ForoUdecContext("idioma"))
            {
                datos = db.formularios.ToList();
            }
            return datos;

        }
        public void agregarIdioma(idioma neww)
        {
            using (ForoUdecContext db = new ForoUdecContext("idioma"))
            {
                db.idiomas.Add(neww);
                db.SaveChanges();
            }

        }
        public void eliminarIdioma(Int32 id)
        {

            using (ForoUdecContext db = new ForoUdecContext("idioma"))
            {
                idioma neww = db.idiomas.Find(id);
                db.idiomas.Remove(neww);
                db.SaveChanges();
            }

        }
        public void agregarIdiomaControl(controle neww)
        {
            using (ForoUdecContext db = new ForoUdecContext("controles"))
            {
                db.controles.Add(neww);
                db.SaveChanges();
            }

        }
    }
}
