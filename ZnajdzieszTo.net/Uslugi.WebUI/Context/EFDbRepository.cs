﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uslugi.Domain.Abstract;
using Uslugi.Domain.Entities;

namespace Uslugi.WebUI.Context
{
    public class EFDbRepository : IOfferRepository
    {
        public EfDbContext context = new EfDbContext();

        public IEnumerable<Offer> Offers{
            get{
                return context.Offers;
            }
        }
    }
}