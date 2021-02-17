using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public abstract class Spell
    {
        // Level of Spell
        public abstract int Level { get; protected set; }

        // Spell's Name
        public abstract string Name { get; protected set; }

        // Spell Description, what it does.
        public abstract string Effect { get; protected set; }
    }
}