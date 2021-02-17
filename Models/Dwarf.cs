using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public class Dwarf : CharacterRace
    {
        public override string Description { get; protected set; } = "Dwarf Desc";
        public override int StrengthBonus { get; protected set; } = 0;
        public override int DexterityBonus { get; protected set; } = 0;
        public override int ConstituionBonus { get; protected set; } = 2;
        public override int IntelligenceBonus { get; protected set; } = 0;
        public override int WisdomBonus { get; protected set; } = 2;
        public override int CharismaBonus { get; protected set; } = -2;
    }
}