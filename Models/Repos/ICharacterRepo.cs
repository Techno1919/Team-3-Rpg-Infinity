using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models.Repos
{
    public interface ICharacterRepo
    {
        IEnumerable<Character> GetAllCharacters();

        bool AddCharacter(Character character);

        bool DeleteCharacter(int charId);

        bool UpdateCharacter(Character character);
    }
}