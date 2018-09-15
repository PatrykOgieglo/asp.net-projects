using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myTarantulas.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Tarantula> Tarantulas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OtherTarantulas> OtherTarantulas { get; set; }
    }
}
