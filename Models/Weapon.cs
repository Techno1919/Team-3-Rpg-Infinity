using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public abstract class Weapon
    {
        public abstract string Name { get; protected set; }
        public abstract int MinimumDamage { get; protected set; }
        public abstract int MaximumDamage { get; protected set; }
    }
}