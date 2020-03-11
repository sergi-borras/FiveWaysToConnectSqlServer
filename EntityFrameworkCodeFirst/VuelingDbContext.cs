using System.Data.Entity;

namespace EntityFrameworkCodeFirst
{
    public class VuelingDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public VuelingDbContext() : base("name=VuelingConnection")
        {}
       

    }
}
