using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public class Dwarf : CharacterRace
    {
        public Dwarf()
        {
            StrengthBonus = 0;
            DexterityBonus = 0;
            ConstituionBonus = 2;
            IntelligenceBonus = 0;
            WisdomBonus = 2;
            CharismaBonus = -2;
        }
    }
}