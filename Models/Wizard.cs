using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public class Wizard : CharacterClass
    {
        public override int HitDie { get; protected set; } = 6;
        public override float AttackBonusPerLevel { get; protected set; } = 0.5f;
        public override string Description { get; protected set; } = "Wiard";
    }
}