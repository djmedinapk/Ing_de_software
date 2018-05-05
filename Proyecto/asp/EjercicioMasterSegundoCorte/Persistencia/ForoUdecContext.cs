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
        public DbSet<contacto> contactos { get; set; }
        public DbSet<idioma> idiomas { get; set; }
        public DbSet<formulario> formularios { get; set; }
        public DbSet<controle> controles { get; set; }
        public DbSet<user_session> user_sessiones { get; set; }
        public DbSet<usuario> usuarios { get; set; }
        public DbSet<publicacion> publicaciones { get; set; }
        public DbSet<denuncia_comentario> denuncia_comentarios { get; set; }
    }
}
