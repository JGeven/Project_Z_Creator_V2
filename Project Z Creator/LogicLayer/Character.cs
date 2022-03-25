using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.DatabaseLayer;

namespace Project_Z_Creator
{
    public class Character
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Traits { get; set; }
    

        public Character(CharacterDTO Character)
        {
            this.Name = Character.Name;
            this.Cost = Character.Cost;
        }
        public Character()
        {
            this.Cost = 8;
        }

        public Character (string Name)
        {
            this.Name = Name;
        }
        public Character(string Name, int Cost)
        {
            this.Name = Name;  
            this.Cost = Cost;
        }


        //Vanaf hier gaat het waarschijnlijk fout, moet eigenlijk naar container? Vraag feedback?

        private CharacterDTO ToDTO()
        {
            CharacterDTO DTO = new CharacterDTO();
            DTO.Name = Name;
            DTO.Cost = Cost;
            return DTO;
        }


        public bool SaveChar()
        {
            CharacterDAL dal = new CharacterDAL();
            CharacterDTO DTO = ToDTO();
            return dal.SaveCharacter(DTO);
        }
        
        
        public int GiveName()
        {
            CharacterDAL dal = new CharacterDAL();
            CharacterDTO DTO = ToDTO();
            return dal.GetCost(DTO);
        }
    }


}
