using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Uslugi.Domain.Abstract;
using Uslugi.Domain.Entities;

namespace Uslugi.WebUI.Context
{
    public class EfDbContext : DbContext, IMyContext
    {
        public DbSet<Offer> Offers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}