using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Uidioma_controles
    {
        private Int32 idioma;
        private String control;
        private Int32 formulario;
        private String texto;

        public string Control { get => control; set => control = value; }
        public int Formulario { get => formulario; set => formulario = value; }
        public int Idioma { get => idioma; set => idioma = value; }
        public string Texto { get => texto; set => texto = value; }
    }
}
