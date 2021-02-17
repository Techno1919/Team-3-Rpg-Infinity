using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public abstract class CharacterClass
    {
        public abstract int HitDie { get; protected set; }

        public abstract float AttackBonusPerLevel { get; protected set; }

        public abstract string Description { get; protected set; }
    }
}