using System.Data.Entity;
using Demo.Core.Database.Model;

namespace Demo.Core.Database
{
    public class DomainModelContainer : DbContext, IDomainModelContainer
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DomainModelContainer() : base("name=DemoDb")
        {

        }
    }

    public interface IDomainModelContainer
    {
        System.Data.Entity.Database Database { get; }
        DbSet<Student> Students { get; set; }
    }
}