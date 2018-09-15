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
    public class EFOtherTarantulasRepository : IOtherTarantulaRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<OtherTarantulas> OtherTarantulas{
            get{
                return context.OtherTarantulas; }
        }

        public void AddOtherTarantula(OtherTarantulas other)
        {
            context.OtherTarantulas.Add(other);
            context.SaveChanges();
        }

        public void DeleteOtherTarantula(int otherID)
        {
            var tDelete = context.OtherTarantulas.Where(a => a.OtherTarantulaID == otherID).FirstOrDefault();
            context.OtherTarantulas.Remove(tDelete);
            context.SaveChanges();
        }

        public void EditOtherTarantula(OtherTarantulas other)
        {
            context.Entry(other).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteFromSellList(int otherID)
        {
            var tDeleteSell = context.OtherTarantulas.Where(a => a.OtherTarantulaID == otherID).FirstOrDefault();
            tDeleteSell.Price = null;
            context.Entry(tDeleteSell).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
