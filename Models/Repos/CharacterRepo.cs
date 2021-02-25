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
        private string _connString = ConfigurationManager.ConnectionStrings["RPGInfinityEntities"].ConnectionString;
        private IList<Character> _characterList;

        public CharacterRepo()
        {
            if (Equals(_characterList, null))
            {
                _characterList = new List<Character>();
            }
        }

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

                cmd.Parameters.AddWithValue("@CharClass", 1);
                cmd.Parameters.AddWithValue("@CharRace", 1);
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

        public bool DeleteCharacter(int charId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            //
            using (var con = new SqlConnection(_connString))
            {
                //
                var cmd = new SqlCommand("SELECT * FROM Characters", con);
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
                    _characterList.Add(cha);
                }
            }
            //
            return _characterList;
        }

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
                cmd.Parameters.AddWithValue("@ID", character.ID);
                cmd.Parameters.AddWithValue("@CharClass", 1);
                cmd.Parameters.AddWithValue("@CharRace", 1);
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

            }
            //
            //
            return chaDetails;
        }
    }
}