using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TaskList.Modelo.Entidades;

namespace TaskList.Data.Infra
{
    internal class Contexto : DbContext
    {
        public DbSet<ItemTask> Tasks { get; set; }

        public Contexto() : base("Name=TaskList")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Contexto>());
            Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConve‌​ntion>();
        }
    }
}
