using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        [MinLength(4, ErrorMessage = "Username must be 4 characters or longer.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(7, ErrorMessage = "Password must be 7 characters or longer.")]
        public string Password { get; set; }
    }
}