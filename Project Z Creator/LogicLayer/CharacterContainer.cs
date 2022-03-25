using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using Project_Z_Creator.DatabaseLayer;

namespace Project_Z_Creator
{
    internal class CharacterContainer
    {
        public List<Character> GetCharacters()
        {
            List<Character> characters = new List<Character>();
            CharacterDAL dal = new CharacterDAL();
            List<CharacterDTO> list = dal.GetCharacters();
            foreach (CharacterDTO character in list)
            {
                Character newCharacter = new Character(character);
                characters.Add(newCharacter);
            }
            return characters;
        }

        //Werkt nog niet Meer onderzoeken
        public Character GetCost()
        {
            Character character = new Character();
            CharacterDAL dal = new CharacterDAL();

            character.Cost = dal.GetCost();
            return character;
        }
            
    }
}
