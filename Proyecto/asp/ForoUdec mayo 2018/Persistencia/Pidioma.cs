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

        public List<Idioma> cargarIdioma()
        {
            List<Idioma> datos = new List<Idioma>();
            using (ForoUdecContext db = new ForoUdecContext("idioma"))
            {
                datos = db.idiomas.ToList();
            }
            return datos;

        }
        public List<Formulario> cargarForm()
        {
            List<Formulario> datos = new List<Formulario>();
            using (ForoUdecContext db = new ForoUdecContext("idioma"))
            {
                datos = db.formularios.ToList();
            }
            return datos;

        }
        public void agregarIdioma(Idioma neww)
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
                Idioma neww = db.idiomas.Find(id);
                db.idiomas.Remove(neww);
                db.SaveChanges();
            }

        }
        public void agregarIdiomaControl(Controle neww)
        {
            using (ForoUdecContext db = new ForoUdecContext("controles"))
            {
                db.controles.Add(neww);
                db.SaveChanges();
            }

        }
    }
}
