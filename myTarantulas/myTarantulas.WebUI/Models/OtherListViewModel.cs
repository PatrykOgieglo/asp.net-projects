using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTarantulas.WebUI.Models
{
    public class OtherListViewModel
    {
        public IEnumerable<OtherTarantulas> OtherTarantulas { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}