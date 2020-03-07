using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    public class VuelingDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public VuelingDbContext() : base("name=VuelingConnection")
        {}
       

    }
}
