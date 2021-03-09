using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace RpgInfinity.Models
{
    [Table("Characters")]
	public class Character
	{
        [Key]
        public int ID { get; set; }

        public int UserId { get; set; }

        public static List<string> alignments = new List<string>()
        {
            "Lawful_Good",
            "Neutral_Good",
            "Chaotic_Good",
            "Lawful_Neutral",
            "True_Neutral",
            "Chaotic_Neutral",
            "Lawful_Evil",
            "Neutral_Evil",
            "Chaotic_Evil"
        };

        public static List<SelectListItem> classList = new List<SelectListItem>()
        {
            new SelectListItem {Text = "Wizard", Value = "1"},
            new SelectListItem {Text = "Cleric", Value = "2"},
            new SelectListItem {Text = "Rogue", Value = "3"},
            new SelectListItem {Text = "Warrior", Value = "4"},
        };

        public static List<SelectListItem> raceList = new List<SelectListItem>()
        {
            new SelectListItem {Text = "Human", Value = "1"},
            new SelectListItem {Text = "Elf", Value = "2"},
            new SelectListItem {Text = "Dwarf", Value = "3"}
        };


        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Class is Required")]
        [Display(Name="Class")]
        public string ClassString { get; set; }
        public int CharClassId { get; set; }
        [Required(ErrorMessage = "Race is Required")]
        [Display(Name = "Race")]
        public string RaceString { get; set; }
        public int CharRaceId { get; set; }
        [Required(ErrorMessage = "Alignment is Required")]
        public string Alignment { get; set; }

        [Required(ErrorMessage = "Strength is Required")]
        [Range(3, 18)]
        public int Strength { get; set; }
        [Required(ErrorMessage = "Dexterity is Required")]
        [Range(3, 18)]
        public int Dexterity { get; set; }
        [Required(ErrorMessage = "Constitution is Required")]
        [Range(3, 18)]
        public int Constitution { get; set; }
        [Required(ErrorMessage = "Intelligence is Required")]
        [Range(3, 18)]
        public int Intelligence { get; set; }
        [Required(ErrorMessage = "Wisdom is Required")]
        [Range(3, 18)]
        public int Wisdom { get; set; }
        [Required(ErrorMessage = "Charisma is Required")]
        [Range(3, 18)]
        public int Charisma { get; set; }
        public string Countries { get; set; }

        [Required(ErrorMessage = "Level is Required")]
        public int Level { get; set; } = 1;
        [Required(ErrorMessage = "Health is Required")]
        public int Health { get; set; }
        [Required(ErrorMessage = "Armor Class is Required")]
        public int ArmorClass { get; set; }
        [Required(ErrorMessage = "Base Attack Bonus is Required")]
        public int BaseAttackBonus { get; set; }

        public int StrengthBonus { get; private set; }
        public int DexterityBonus { get; private set; }
        public int ConstitutionBonus { get; private set; }
        public int IntelligenceBonus { get; private set; }
        public int WisdomBonus { get; private set; }
        public int CharismaBonus { get; private set; }

        public string Backstory { get; set; }

        public bool isSpellCaster { get; set; }
        /*
        public List<Spell> SpellsList 
        {
            get
            {
                if (SpellsList == null)
                {
                    SpellsList = new List<Spell>();
                }
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
        */

        public CharacterClass CharClass { get; set; }
        public CharacterRace CharRace { get; set; }

        public void AddRaceStatBonuses()
        {
            Strength += CharRace.StrengthBonus;
            Dexterity += CharRace.DexterityBonus;
            Constitution += CharRace.ConstitutionBonus;
            Intelligence += CharRace.IntelligenceBonus;
            Wisdom += CharRace.WisdomBonus;
            Charisma += CharRace.CharismaBonus;
        }

        public void SetStatBonuses()
        {
            StrengthBonus = SetStatBonus(Strength);
            DexterityBonus = SetStatBonus(Dexterity);
            ConstitutionBonus =  SetStatBonus(Constitution);
            IntelligenceBonus = SetStatBonus(Intelligence);
            WisdomBonus = SetStatBonus(Wisdom);
            CharismaBonus = SetStatBonus(Charisma);
        }

        private int SetStatBonus(int stat)
        {
            int tempBonus = (stat - 10) / 2;
            if (stat < 10)
            {
                if (stat % 2 == 1)
                {
                    tempBonus -= 1;
                }
            }

            return tempBonus;
        }

        public void LevelUp()
        {
            Random gen = new Random();
            Level++;

            Health += (gen.Next(CharClass.HitDie + ConstitutionBonus) + 1);
            BaseAttackBonus = GetBaseAttackBonus(Level);
        }

        public int GetBaseAttackBonus(int level = 1)
        {
            return (int)(level * CharClass.AttackBonusPerLevel);
        }

        /*
        public void AddSpell(Spell spell)
        {
            if (isSpellCaster)
            {
                SpellsList.Add(spell);
            }
        }
        */
    }


}
