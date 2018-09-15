using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTarantulas.WebUI.Models
{
    public class ProfilModel
    {
        public IEnumerable<Tarantula> Tarantulas { get; set; }
        public User User { get; set; }
    }
}