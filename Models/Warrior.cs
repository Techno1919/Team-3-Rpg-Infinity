using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public class Warrior : CharacterClass
    {
        public override int HitDie { get; protected set; } = 10;
        public override float AttackBonusPerLevel { get; protected set; } = 1.0f;
        public override string Description { get; protected set; } = "Fighter";
    }
}