using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myTarantulas.Domain.Abstract
{
    public interface IOtherTarantulaRepository
    {
        IEnumerable<OtherTarantulas> OtherTarantulas { get; }
        void AddOtherTarantula(OtherTarantulas other);
        void DeleteOtherTarantula(int otherID);
        void EditOtherTarantula(OtherTarantulas other);
        void DeleteFromSellList(int otherID);
    }
}
