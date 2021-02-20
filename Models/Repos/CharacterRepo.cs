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
        private string _connString = "metadata=res://*/RPGInfinityDB.csdl|res://*/RPGInfinityDB.ssdl|res://*/RPGInfinityDB.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=rpg-infinity.database.windows.net;initial catalog=RPGInfinity;persist security info=True;user id=login;password=Password123;MultipleActiveResultSets=True;App=EntityFramework&quot;";//ConfigurationManager.ConnectionStrings["RPGInfinityEntities"].ConnectionString;
        private IList<Character> _characterList;

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
                cmd.Parameters.AddWithValue("@Name", character.Name);
                cmd.Parameters.AddWithValue("@Gender", character.Gender);
                cmd.Parameters.AddWithValue("@Alignment", character.Alignment);
                cmd.Parameters.AddWithValue("@CharClass", character.CharClass);
                cmd.Parameters.AddWithValue("@CharRace", character.CharRace);
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
                cmd.Parameters.AddWithValue("@Backstory", character.Backstory);
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
            throw new NotImplementedException();
        }

        public bool UpdateCharacter(Character character)
        {
            throw new NotImplementedException();
        }
    }
}