using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    [Table("CharacterRace")]
    public class CharacterRace
    {
        public enum eRace
        {
            Human = 1,
            Dwarf = 2,
            Elf = 3
        }

        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public int StrengthBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int ConstitutionBonus { get; set; }
        public int IntelligenceBonus { get; set; }
        public int WisdomBonus { get; set; }
        public int CharismaBonus { get; set; }
        public string Description { get; set; }

    }
}