﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class comentario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public comentario()
        {
            this.denuncia_comentario = new HashSet<denuncia_comentario>();
            this.comentario1 = new HashSet<comentario>();
        }

        public long id { get; set; }
        public string contenido { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<long> id_comentario { get; set; }
        public Nullable<long> id_usuario { get; set; }
        public Nullable<long> id_publicacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<denuncia_comentario> denuncia_comentario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comentario> comentario1 { get; set; }
        public virtual comentario comentario2 { get; set; }
        public virtual publicacion publicacion { get; set; }
        public virtual user_session user_session { get; set; }
    }
}
