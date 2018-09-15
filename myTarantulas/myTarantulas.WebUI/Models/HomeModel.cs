using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTarantulas.WebUI.Models
{
    public class HomeModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Tarantula> Tarantula { get; set; }
        public IEnumerable<OtherTarantulas> Other { get; set; }

    }
}