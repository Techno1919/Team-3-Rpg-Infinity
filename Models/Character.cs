using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Character Class is Required")]
        [Display(Name="Class")]
        public int CharClassId { get; set; }
        [Required(ErrorMessage = "Character Race is Required")]
        [Display(Name = "Race")]
        public int CharRaceId { get; set; }
        [Required(ErrorMessage = "Alignment is Required")]
        public string Alignment { get; set; }

        [Required(ErrorMessage = "Strength is Required")]
        public int Strength { get; set; }
        [Required(ErrorMessage = "Dexterity is Required")]
        public int Dexterity { get; set; }
        [Required(ErrorMessage = "Constitution is Required")]
        public int Constitution { get; set; }
        [Required(ErrorMessage = "Intelligence is Required")]
        public int Intelligence { get; set; }
        [Required(ErrorMessage = "Wisdom is Required")]
        public int Wisdom { get; set; }
        [Required(ErrorMessage = "Charisma is Required")]
        public int Charisma { get; set; }
        public string Countries { get; set; }

        [Required(ErrorMessage = "Level is Required")]
        public int Level { get; set; }
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

        public CharacterClass.eClass eClass;
        public CharacterRace.eRace eRace;

        public CharacterClass CharClass { get; set; }
        public CharacterRace CharRace { get; set; }

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
            var tempBonus = (stat - 10) / 2;

            return tempBonus;
        }

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


}
