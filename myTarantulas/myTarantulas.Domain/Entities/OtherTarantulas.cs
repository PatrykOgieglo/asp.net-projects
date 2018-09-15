using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myTarantulas.Domain.Entities
{
    public class OtherTarantulas
    {
        [Key]
        public int OtherTarantulaID { get; set; }

        [Required]
        public string Type { get; set; }

        public string Phase { get; set; }

        [Required]
        public int NumberOf { get; set; }

        [Required]
        public string Sex { get; set; }

        public decimal? Price { get; set; }

        public int? UserID { get; set; }
    }
}
