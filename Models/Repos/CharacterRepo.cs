using RpgInfinity.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models.Repos
{
    public class CharacterRepo : ICharacterRepo
    {
        #region Properties
        private string _connString = ConfigurationManager.ConnectionStrings["RPGInfinityEntities"].ConnectionString;
        private IList<Character> _characterList;
        private Random random = new Random();
        #endregion

        #region Constructor
        public CharacterRepo()
        {
            if (Equals(_characterList, null))
            {
                _characterList = new List<Character>();
            }
        }
        #endregion

        #region AddCharacter(Character character)
        public bool AddCharacter(Character character)
        {
            var retVal = false;

            using (var con = new SqlConnection(_connString))
            {
                //
                // Set-up command
                var cmd = new SqlCommand("AddNewCharacter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //
                // Define StoredProc parameters

                // Setting UserId
                var _id = 0;
                if(HomeController._currentUser == null)
                {
                    _id = 1;
                }
                else
                {
                    _id = HomeController._currentUser.ID;
                }

                int.TryParse(character.ClassString, out var v);
                int.TryParse(character.RaceString, out var b);

                character.CharRace = GetCharacterRace(b);
                character.CharClass = GetCharacterClass(v);
                character.AddRaceStatBonuses();
                character.SetStatBonuses();

                cmd.Parameters.AddWithValue("@CharClass", v);
                cmd.Parameters.AddWithValue("@CharRace", b);
                cmd.Parameters.AddWithValue("@Alignment", character.Alignment);
                cmd.Parameters.AddWithValue("@Name", character.Name);
                cmd.Parameters.AddWithValue("@Gender", character.Gender);
                cmd.Parameters.AddWithValue("@Backstory", character.Backstory);
                cmd.Parameters.AddWithValue("@IsSpellCaster", character.isSpellCaster);
                cmd.Parameters.AddWithValue("@Level", character.Level);
                cmd.Parameters.AddWithValue("@Health", character.Health);
                cmd.Parameters.AddWithValue("@ArmorClass", character.ArmorClass);
                cmd.Parameters.AddWithValue("@BaseAttackBonus", character.BaseAttackBonus);
                cmd.Parameters.AddWithValue("@Strength", character.Strength);
                cmd.Parameters.AddWithValue("@Dexterity", character.Dexterity);
                cmd.Parameters.AddWithValue("@Constitution", character.Constitution);
                cmd.Parameters.AddWithValue("@Intelligence", character.Intelligence);
                cmd.Parameters.AddWithValue("@Wisdom", character.Wisdom);
                cmd.Parameters.AddWithValue("@Charisma", character.Charisma);
                cmd.Parameters.AddWithValue("@UserId", _id);
                //
                // Open DB Connection
                con.Open();
                //
                // Execute command
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    retVal = true;
                }
            }
            //
            // Return Success / Failure
            return retVal;
        }
        #endregion

        #region AddRandomCharacter(Character character)
        public bool AddRandomCharacter(Character character)
        {
            var retVal = false;

            using (var con = new SqlConnection(_connString))
            {
                //
                // Set-up command
                var cmd = new SqlCommand("AddNewCharacter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //
                // Define StoredProc parameters

                // Setting UserId
                var _id = 0;
                if (HomeController._currentUser == null)
                {
                    _id = 1;
                }
                else
                {
                    _id = HomeController._currentUser.ID;
                }
                var classValue = Character.classList[random.Next(0, 4)];
                var raceValue = Character.raceList[random.Next(0, 3)];
                var alignment = Character.alignments[random.Next(0, 9)];

                character.Strength = RollStat();
                character.Dexterity = RollStat();
                character.Constitution = RollStat();
                character.Intelligence = RollStat();
                character.Wisdom = RollStat();
                character.Charisma = RollStat();

                character.CharRace = GetCharacterRace(int.Parse(raceValue.Value));
                character.CharClass = GetCharacterClass(int.Parse(classValue.Value));
                character.AddRaceStatBonuses();
                character.SetStatBonuses();

                cmd.Parameters.AddWithValue("@CharClass", classValue.Value);
                cmd.Parameters.AddWithValue("@CharRace", raceValue.Value);
                cmd.Parameters.AddWithValue("@Alignment", alignment);
                cmd.Parameters.AddWithValue("@Name", character.Name);
                cmd.Parameters.AddWithValue("@Gender", character.Gender);
                cmd.Parameters.AddWithValue("@Backstory", character.Backstory);
                cmd.Parameters.AddWithValue("@IsSpellCaster", character.isSpellCaster);
                cmd.Parameters.AddWithValue("@Level", 1);
                cmd.Parameters.AddWithValue("@Health", (Roll(1, character.CharClass.HitDie) + character.ConstitutionBonus));
                cmd.Parameters.AddWithValue("@ArmorClass", character.DexterityBonus + 10);
                cmd.Parameters.AddWithValue("@BaseAttackBonus", character.GetBaseAttackBonus(1));
                cmd.Parameters.AddWithValue("@Strength", character.Strength);
                cmd.Parameters.AddWithValue("@Dexterity", character.Dexterity);
                cmd.Parameters.AddWithValue("@Constitution", character.Constitution);
                cmd.Parameters.AddWithValue("@Intelligence", character.Intelligence);
                cmd.Parameters.AddWithValue("@Wisdom", character.Wisdom);
                cmd.Parameters.AddWithValue("@Charisma", character.Charisma);
                cmd.Parameters.AddWithValue("@UserId", _id);
                //
                // Open DB Connection
                con.Open();
                //
                // Execute command
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    retVal = true;
                }
            }
            //
            // Return Success / Failure
            return retVal;
        }
        #endregion

        #region DeleteCharacter(int charId)
        public bool DeleteCharacter(int charId)
        {
            var retVal = false;

            using (var con = new SqlConnection(_connString))
            {
                //
                // Set-up command
                var cmd = new SqlCommand("DeleteCharacter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //
                // Define StoredProc parameters
                cmd.Parameters.AddWithValue("@ID", charId);
                //
                // Open DB Connection
                con.Open();
                //
                // Execute command
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    retVal = true;
                }
            }
            //
            // Return Success / Failure
            return retVal;
        }
        #endregion

        #region GetAllCharacters()
        public IEnumerable<Character> GetAllCharacters()
        {
            int id;
            if (HomeController._currentUser == null)
            {
                id = 1;
            }
            else
            {
                id = HomeController._currentUser.ID;
            }

            //
            using (var con = new SqlConnection(_connString))
            {
                //
                var cmd = new SqlCommand($"select * from Characters where UserId = 1 or UserId = {id}", con);
                cmd.CommandType = CommandType.Text;
                //
                con.Open();
                //
                SqlDataReader rdr = cmd.ExecuteReader();
                //
                while (rdr.Read())
                {
                    //
                    var cha = new Character();
                    //
                    cha.ID = Convert.ToInt32(rdr["Id"]);
                    cha.CharClassId = (int)rdr["CharClass"];
                    cha.CharRaceId = (int)rdr["CharRace"];
                    cha.Alignment = rdr["Alignment"].ToString();
                    cha.Name = rdr["Name"].ToString();
                    cha.Gender = rdr["Gender"].ToString();
                    cha.Backstory = rdr["Backstory"].ToString();
                    cha.isSpellCaster = Convert.ToBoolean(rdr["isSpellCaster"]);
                    cha.Level = (int)rdr["Level"];
                    cha.Health = (int)rdr["Health"];
                    cha.ArmorClass = (int)rdr["ArmorClass"];
                    cha.BaseAttackBonus = (int)rdr["BaseAttackBonus"];
                    cha.Strength = (int)rdr["Strength"];
                    cha.Dexterity = (int)rdr["Dexterity"];
                    cha.Constitution = (int)rdr["Constitution"];
                    cha.Intelligence = (int)rdr["Intelligence"];
                    cha.Wisdom = (int)rdr["Wisdom"];
                    cha.Charisma = (int)rdr["Charisma"];

                    //
                    // Add your object to your list
                    cha.SetStatBonuses();
                    _characterList.Add(cha);
                }
            }
            //
            return _characterList;
        }
        #endregion

        #region UpdateCharacter(Character character)
        public bool UpdateCharacter(Character character)
        {
            var retVal = false;

            using (var con = new SqlConnection(_connString))
            {
                //
                // Set-up command
                var cmd = new SqlCommand("UpdateCharacter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //
                // Define StoredProc parameters

                var _id = 0;
                if (HomeController._currentUser == null)
                {
                    _id = 1;
                }
                else
                {
                    _id = HomeController._currentUser.ID;
                }

                int.TryParse(character.ClassString, out var v);
                int.TryParse(character.RaceString, out var b);
                cmd.Parameters.AddWithValue("@ID", character.ID);
                cmd.Parameters.AddWithValue("@CharClass", v);
                cmd.Parameters.AddWithValue("@CharRace", b);
                cmd.Parameters.AddWithValue("@Alignment", character.Alignment);
                cmd.Parameters.AddWithValue("@Name", character.Name);
                cmd.Parameters.AddWithValue("@Gender", character.Gender);
                cmd.Parameters.AddWithValue("@Backstory", character.Backstory);
                cmd.Parameters.AddWithValue("@IsSpellCaster", character.isSpellCaster);
                cmd.Parameters.AddWithValue("@Level", character.Level);
                cmd.Parameters.AddWithValue("@Health", character.Health);
                cmd.Parameters.AddWithValue("@ArmorClass", character.ArmorClass);
                cmd.Parameters.AddWithValue("@BaseAttackBonus", character.BaseAttackBonus);
                cmd.Parameters.AddWithValue("@Strength", character.Strength);
                cmd.Parameters.AddWithValue("@Dexterity", character.Dexterity);
                cmd.Parameters.AddWithValue("@Constitution", character.Constitution);
                cmd.Parameters.AddWithValue("@Intelligence", character.Intelligence);
                cmd.Parameters.AddWithValue("@Wisdom", character.Wisdom);
                cmd.Parameters.AddWithValue("@Charisma", character.Charisma);
                cmd.Parameters.AddWithValue("@UserId", _id);
                //
                // Open DB Connection
                con.Open();
                //
                // Execute command
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    retVal = true;
                }
            }
            //
            // Return Success / Failure
            return retVal;
        }
        #endregion

        #region GetCharacter(int id)
        public Character GetCharacter(int id)
        {
            Character chaDetails;

            using (var con = new SqlConnection(_connString))
            {
                //
                // Set-up command
                var cmd = new SqlCommand("GetCharacterDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //
                // Define StoredProc parameters
                cmd.Parameters.AddWithValue("@ID", id);
                //
                // Open DB Connection
                con.Open();
                //
                // Execute command
                var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                //
                // Read the data
                rdr.Read();
                //
                // Populate our Student model
                chaDetails = new Character
                {
                    ID = Convert.ToInt32(rdr["Id"]),
                    CharClassId = (int)rdr["CharClass"],
                    CharRaceId = (int)rdr["CharRace"],
                    Alignment = rdr["Alignment"].ToString(),
                    Name = rdr["Name"].ToString(),
                    Gender = rdr["Gender"].ToString(),
                    Backstory = rdr["Backstory"].ToString(),
                    isSpellCaster = Convert.ToBoolean(rdr["isSpellCaster"]),
                    Level = (int)rdr["Level"],
                    Health = (int)rdr["Health"],
                    ArmorClass = (int)rdr["ArmorClass"],
                    BaseAttackBonus = (int)rdr["BaseAttackBonus"],
                    Strength = (int)rdr["Strength"],
                    Dexterity = (int)rdr["Dexterity"],
                    Constitution = (int)rdr["Constitution"],
                    Intelligence = (int)rdr["Intelligence"],
                    Wisdom = (int)rdr["Wisdom"],
                    Charisma = (int)rdr["Charisma"]
                };
                chaDetails.SetStatBonuses();
                chaDetails.CharClass = GetCharacterClass(chaDetails.CharClassId);
                chaDetails.CharRace = GetCharacterRace(chaDetails.CharRaceId);
            }
            //
            //
            return chaDetails;
        }
        #endregion

        #region GetCharacterClass(int id)
        public CharacterClass GetCharacterClass(int id)
        {
            CharacterClass classDetails;

            using (var con = new SqlConnection(_connString))
            {
                //
                // Set-up command
                var cmd = new SqlCommand("GetClassDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //
                // Define StoredProc parameters
                cmd.Parameters.AddWithValue("@ID", id);
                //
                // Open DB Connection
                con.Open();
                //
                // Execute command
                var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                //
                // Read the data
                rdr.Read();
                //
                // Populate our Student 
                var v = rdr["HitDie"];
                var d = rdr["AttackBonusPerLevel"];

                classDetails = new CharacterClass();
                classDetails.ID = Convert.ToInt32(rdr["Id"]);
                classDetails.Name = rdr["ClassString"].ToString();
                classDetails.HitDie = Convert.ToInt32(rdr["HitDie"]);
                float.TryParse(rdr["AttackBonusPerLevel"].ToString(), out float test);
                classDetails.AttackBonusPerLevel = test;
                classDetails.Description = rdr["Description"].ToString();

            }
            //
            //
            return classDetails;
        }
        #endregion

        #region GetCharacterRace(int id)
        public CharacterRace GetCharacterRace(int id)
        {
            CharacterRace raceDetails;

            using (var con = new SqlConnection(_connString))
            {
                //
                // Set-up command
                var cmd = new SqlCommand("GetRaceDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //
                // Define StoredProc parameters
                cmd.Parameters.AddWithValue("@ID", id);
                //
                // Open DB Connection
                con.Open();
                //
                // Execute command
                var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                //
                // Read the data
                rdr.Read();
                //
                // Populate our Student model
                raceDetails = new CharacterRace
                {
                    ID = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["RaceString"].ToString(),
                    StrengthBonus = (int)rdr["StrengthBonus"],
                    DexterityBonus = (int)rdr["DexterityBonus"],
                    ConstitutionBonus = (int)rdr["ConstitutionBonus"],
                    IntelligenceBonus = (int)rdr["IntelligenceBonus"],
                    WisdomBonus = (int)rdr["WisdomBonus"],
                    CharismaBonus = (int)rdr["CharismaBonus"],
                    Description = rdr["Description"].ToString()
                };
            }
            //
            //
            return raceDetails;
        }
        #endregion

        #region RollStat()
        public int RollStat()
        {
            return Roll(3, 6);
        }
        #endregion

        #region Roll(int numDice, int numSides)
        public int Roll(int numDice, int numSides)
        {
            var roll = 0;
            for (int i = 0; i < numDice; i++)
            {
                roll += random.Next(1, (numSides+1));
            }

            return roll;
        }
        #endregion
    }
}