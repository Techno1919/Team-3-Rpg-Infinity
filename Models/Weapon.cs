using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public class Weapon
    {
        public string Name { get; protected set; }
        public int MinimumDamage { get; protected set; }
        public int MaximumDamage { get; protected set; }
    }
}