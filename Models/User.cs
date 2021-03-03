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
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 50 characters long.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Password must be between 4 and 50 characters long.")]
        public string Password { get; set; }
    }
}