using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uslugi.Domain.Entities
{
    public class Offer
    {
        public int OfferID { get; set; }

        [Required(ErrorMessage = "Podaj nazwę ogłoszenia")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj kategorię")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Podaj miasto")]
        public string City { get; set; }
    }
}
