using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models
{
    public class Spell
    {
        // Level of Spell
        public int Level { get; protected set; }

        // Spell's Name
        public string Name { get; protected set; }

        // Spell Description, what it does.
        public string Effect { get; protected set; }
    }
}