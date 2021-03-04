using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    [Table("CharacterClass")]
    public class CharacterClass
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Class")]
        public string Name { get; set; }

        public int HitDie { get; set; }

        public float AttackBonusPerLevel { get; set; }

        public string Description { get; set; }
    }
}