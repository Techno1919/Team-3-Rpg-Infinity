using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    [Table("")]
    public abstract class CharacterClass
    {
        [Key]
        public int ID { get; set; }

        public abstract int HitDie { get; protected set; }

        public abstract float AttackBonusPerLevel { get; protected set; }

        public abstract string Description { get; protected set; }
    }
}