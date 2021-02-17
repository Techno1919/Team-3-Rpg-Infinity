using System;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace RpgInfinity.Models
{
	public class Character
	{
        public enum eAlignment
        {
            Lawful_Good,
            Neutral_Good,
            Chaotic_Good,
            Lawful_Neutral,
            True_Neutral,
            Chaotic_Neutral,
            Lawful_Evil,
            Neutral_Evil,
            Chaotic_Evil
        }

        public CharacterClass CharClass { get; set; }
        public CharacterRace CharRace { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int Level { get; set; }
        public int AttackBonus { get; set; }
    }
}
