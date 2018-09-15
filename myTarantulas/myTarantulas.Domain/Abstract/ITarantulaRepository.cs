using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myTarantulas.Domain
{
    public interface ITarantulaRepository
    {
        IEnumerable<Tarantula> Tarantulas { get; }
        void AddTarantula(Tarantula tarantula);
        void DeleteTarantula(int tarantulaID);
        void EditTarantula(Tarantula tarantula);
        void DeleteFromSellList(int tarantulaID);
    }
}
