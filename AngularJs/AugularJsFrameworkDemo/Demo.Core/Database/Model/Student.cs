using System.Data.Entity.ModelConfiguration;

namespace Demo.Core.Database.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration() : base() {
            ToTable("Students", "dbo");
            HasKey(x => x.Id);
            Property(x => x.Name);
            Property(x => x.Age);

            //Ignoring mapping property
            //Ignore(m => m.FullName);
            //Property(m => m.Gender);
            //Property(m => m.Name).HasMaxLength(100);

            //One-to-many relationship which the relation item must be set (not null)
            //HasMany(x => x.Friends).WithRequired(x => x.Celebrity);

            //Optional many-to-one relationship
            //HasOptional(x => x.Address);

            //Many-to-many relationship
            //HasMany(t => t.Managers)
            //        .WithMany(t => t.ManagedCelebrities)
            //        .Map(m =>
            //        {
            //            m.ToTable("CelebrityManagers");
            //        });
        }
    }
}