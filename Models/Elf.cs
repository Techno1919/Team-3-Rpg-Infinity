using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public class Elf : CharacterRace
    {
        public Elf()
        {
            StrengthBonus = 0;
            DexterityBonus = 2;
            ConstituionBonus = -2;
            IntelligenceBonus = 2;
            WisdomBonus = 0;
            CharismaBonus = 0;
        }
    }
}