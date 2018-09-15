using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myTarantulas.Domain.Entities;
using System.Data.Entity;

namespace myTarantulas.Domain.Concrete
{
    public class EFTarantulaRepository : ITarantulaRepository
    {
        public EFDbContext context = new EFDbContext();

        public IEnumerable<Tarantula> Tarantulas{
            get{
                return context.Tarantulas; }
        }

        public void AddTarantula(Tarantula tarantula)
        {
            context.Tarantulas.Add(tarantula);
            context.SaveChanges();
        }

        public void DeleteTarantula(int tarantulaID)
        {
            var tDelete = context.Tarantulas.Where(a => a.TarantulaID == tarantulaID).FirstOrDefault();
            context.Tarantulas.Remove(tDelete);
            context.SaveChanges();
        }

        public void EditTarantula(Tarantula tarantula)
        {
            context.Entry(tarantula).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteFromSellList(int tarantulaID)
        {
            var tDeleteSell = context.Tarantulas.Where(a => a.TarantulaID == tarantulaID).FirstOrDefault();
            tDeleteSell.Price = null;
            context.Entry(tDeleteSell).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
