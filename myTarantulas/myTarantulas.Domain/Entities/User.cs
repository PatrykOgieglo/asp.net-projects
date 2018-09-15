using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace myTarantulas.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please type your name")]
        [MinLength(4, ErrorMessage = "Username: Min. 4 letters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please type your E-mail")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "E-mail: Incorrect email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please type your password")]
        [MinLength(8, ErrorMessage = "Password: Min. 8 letters")]       
        public string Password { get; set; }

        public string WebOrFb { get; set; }
    }
}
