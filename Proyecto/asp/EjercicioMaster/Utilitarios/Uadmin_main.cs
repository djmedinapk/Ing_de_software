using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Uadmin_main
    {
        private String ltotalUsers;
        private String hltotalUsers;
        private String ltotalPost;
        private String hltotalPost;
        private String ltotalComentarios;
        private String ltotalPuntos;

        public string LtotalUsers { get => ltotalUsers; set => ltotalUsers = value; }
        public string HltotalUsers { get => hltotalUsers; set => hltotalUsers = value; }
        public string LtotalPost { get => ltotalPost; set => ltotalPost = value; }
        public string HltotalPost { get => hltotalPost; set => hltotalPost = value; }
        public string LtotalComentarios { get => ltotalComentarios; set => ltotalComentarios = value; }
        public string LtotalPuntos { get => ltotalPuntos; set => ltotalPuntos = value; }
    }
}
