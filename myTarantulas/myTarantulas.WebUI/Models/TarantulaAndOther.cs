using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTarantulas.WebUI.Models
{
    public class TarantulaAndOther
    {
        public IEnumerable<Tarantula> Tarantulas { get; set; }
        public IEnumerable<OtherTarantulas> OtherTarantulas { get; set; }
    }
}