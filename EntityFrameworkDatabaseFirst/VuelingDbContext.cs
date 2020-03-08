using System.Data.Entity;

namespace EntityFrameworkDatabaseFirst
{
    public class VuelingDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public VuelingDbContext() : base("name=VuelingContext")
        {}
       

    }
}
