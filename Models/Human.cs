using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public class Human : CharacterRace
    {
        public Human()
        {
            StrengthBonus = 1;
            DexterityBonus = 1;
            ConstituionBonus = 1;
            IntelligenceBonus = 1;
            WisdomBonus = 1;
            CharismaBonus = 1;
        }
    }
}