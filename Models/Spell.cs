using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    [Table("Spells")]
    public class Spell
    {
        [Key]
        public int ID { get; set; }

        // Level of Spell
        public int Level { get; protected set; }

        // Spell's Name
        public string Name { get; protected set; }

        // Spell Description, what it does.
        public string Effect { get; protected set; }
    }
}