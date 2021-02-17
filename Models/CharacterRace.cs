using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public abstract class CharacterRace
    {
        public abstract string Description { get; protected set; }
        public abstract int StrengthBonus { get; protected set; }
        public abstract int DexterityBonus { get; protected set; }
        public abstract int ConstituionBonus { get; protected set; }
        public abstract int IntelligenceBonus { get; protected set; }
        public abstract int WisdomBonus { get; protected set; }
        public abstract int CharismaBonus { get; protected set; }

    }
}