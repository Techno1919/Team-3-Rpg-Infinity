using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public class Rogue : CharacterClass
    {
        public override int HitDie { get; protected set; } = 8;
        public override float AttackBonusPerLevel { get; protected set; } = 0.75f;
        public override string Description { get; protected set; } = "Thief";
    }
}