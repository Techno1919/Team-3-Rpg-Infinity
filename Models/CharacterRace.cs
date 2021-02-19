using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    [Table("")]
    public abstract class CharacterRace
    {
        [Key]
        public int ID { get; set; }

        public abstract string Description { get; protected set; }
        public abstract int StrengthBonus { get; protected set; }
        public abstract int DexterityBonus { get; protected set; }
        public abstract int ConstituionBonus { get; protected set; }
        public abstract int IntelligenceBonus { get; protected set; }
        public abstract int WisdomBonus { get; protected set; }
        public abstract int CharismaBonus { get; protected set; }

    }
}