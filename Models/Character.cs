﻿using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace RpgInfinity.Models
{
	public class Character
	{
        public int ID { get; set; }

        public CharacterClass CharClass { get; set; }
        public CharacterRace CharRace { get; set; }
        public eAlignment Alignment { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Backstory { get; set; }

        public bool isSpellCaster { get; set; }
        public List<Spell> SpellsList 
        {
            get
            {
                return SpellsList;
            }
            set
            {
                if (isSpellCaster)
                {
                    SpellsList = value;
                }
            }
        }

        public int Level { get; set; }
        public int Health { get; set; }
        public int ArmorClass { get; set; }
        public int ConstitutionBonus { get; set; }
        public int BaseAttackBonus { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public void LevelUp()
        {
            Random gen = new Random();
            Level++;

            Health += (gen.Next(CharClass.HitDie + ConstitutionBonus) + 1);
            BaseAttackBonus = (int)(Level * CharClass.AttackBonusPerLevel);
        }

        public void AddSpell(Spell spell)
        {
            if (isSpellCaster)
            {
                SpellsList.Add(spell);
            }
        }
    }

	public enum eAlignment
    {
        Lawful_Good = 1,
        Neutral_Good = 2,
        Chaotic_Good = 3,
        Lawful_Neutral = 4,
        True_Neutral = 5,
        Chaotic_Neutral = 6,
        Lawful_Evil = 7,
        Neutral_Evil = 8,
        Chaotic_Evil = 9
    }
}
