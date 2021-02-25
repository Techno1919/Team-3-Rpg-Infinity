using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    [Table("CharacterClass")]
    public abstract class CharacterClass
    {
        //public List<string> eClass = new List<string>()
        //{
        //    "Wizard",
        //    "Cleric",
        //    "Rogue",
        //    "Warrior"
        //};

        public enum eClass
        {
            Wizard = 1,
            Cleric = 2,
            Rogue = 3,
            Warrior = 4
        }




        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public abstract int HitDie { get; protected set; }

        public abstract float AttackBonusPerLevel { get; protected set; }

        public abstract string Description { get; protected set; }
    }
}