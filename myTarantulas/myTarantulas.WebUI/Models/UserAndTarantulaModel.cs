using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTarantulas.WebUI.Models
{
    public class UserAndTarantulaModel
    {
        public User UserM;
        public int NumberOfTarantula { get; set; }
    }
}