using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myTarantulas.Domain.Entities
{
    public class Tarantula
    {
        [Key]
        public int TarantulaID { get; set; }

        [Required(ErrorMessage = "Please type type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please type phase")]
        public string Phase { get; set; }

        [Required(ErrorMessage = "Please type number")]
        public int NumberOf { get; set; }

        [Required(ErrorMessage = "Please type sex")]
        public string Sex { get; set; }
              
        public decimal? Price { get; set; }

        public int? UserID { get; set; }
    }
}
