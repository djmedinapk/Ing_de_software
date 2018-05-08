using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class publicacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public publicacion()
        {
            this.denuncia_publicacion = new HashSet<denuncia_publicacion>();
            this.comentarios = new HashSet<comentario>();
            this.puntuacions = new HashSet<puntuacion>();
        }

        public long id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string contenido { get; set; }
        public Nullable<long> visitas { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string fuente { get; set; }
        public Nullable<int> id_estado { get; set; }
        public Nullable<long> id_usuario { get; set; }
        public string miniatura { get; set; }
        public string etiquetas { get; set; }
        public Nullable<int> id_categoria { get; set; }
        public string seccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<denuncia_publicacion> denuncia_publicacion { get; set; }
        public virtual categoria categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comentario> comentarios { get; set; }
        public virtual estado estado { get; set; }
        public virtual user_session user_session { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<puntuacion> puntuacions { get; set; }
    }
}
