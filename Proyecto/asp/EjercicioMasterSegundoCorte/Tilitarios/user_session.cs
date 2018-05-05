using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    
        using System;
        using System.Collections.Generic;

    public partial class user_session
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_session()
        {
            this.denuncia_comentario = new HashSet<denuncia_comentario>();
            this.denuncia_publicacion = new HashSet<denuncia_publicacion>();
            this.comentarios = new HashSet<comentario>();
            this.publicacions = new HashSet<publicacion>();
            this.puntuacions = new HashSet<puntuacion>();
            this.bloqueos = new HashSet<bloqueo>();
            this.correo_institucional = new HashSet<correo_institucional>();
            this.usuarios = new HashSet<usuario>();
        }

        public long id { get; set; }
        public string username { get; set; }
        public string pasword { get; set; }
        public Nullable<System.DateTime> fecha_ult_session { get; set; }
        public string correo { get; set; }
        public Nullable<int> estado_session { get; set; }
        public string session { get; set; }
        public Nullable<int> id_permisos { get; set; }
        public Nullable<int> id_estado { get; set; }
        public Nullable<int> intentos_acceso { get; set; }
        public Nullable<int> n_sesiones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<denuncia_comentario> denuncia_comentario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<denuncia_publicacion> denuncia_publicacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comentario> comentarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<publicacion> publicacions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<puntuacion> puntuacions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bloqueo> bloqueos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correo_institucional> correo_institucional { get; set; }
        public virtual estado1 estado1 { get; set; }
        public virtual permiso permiso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuarios { get; set; }
    }

}
