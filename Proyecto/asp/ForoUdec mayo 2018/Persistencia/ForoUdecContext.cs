using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tablas;

namespace Persistencia
{
    public class ForoUdecContext: DbContext
    {
        private readonly string schema;
        public ForoUdecContext(string schema) : base("Postgres")
        {
            this.schema = schema;
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);
            base.OnModelCreating(builder);
        }
        public DbSet<Contacto> contactos { get; set; }
        public DbSet<Idioma> idiomas { get; set; }
        public DbSet<Formulario> formularios { get; set; }
        public DbSet<Controle> controles { get; set; }
        public DbSet<User_session> user_sessiones { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Publicacion> publicaciones { get; set; }
        public DbSet<DenunciaComentario> denuncia_comentarios { get; set; }
    }
}
