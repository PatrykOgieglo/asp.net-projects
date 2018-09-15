using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uslugi.Domain.Entities;

namespace Uslugi.Domain.Abstract
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> Offers { get; }
    }
}
