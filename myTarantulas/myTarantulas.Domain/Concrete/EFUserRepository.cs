using myTarantulas.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myTarantulas.Domain.Entities;
using System.Data.Entity;

namespace myTarantulas.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        public EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users {
            get {
                return context.Users; }
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void AddWebToUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;      
            context.SaveChanges();
        }
    }
}
