using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uslugi.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Proszę podać adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać adres hasło")] 
        public string Password { get; set; }
    }
}
