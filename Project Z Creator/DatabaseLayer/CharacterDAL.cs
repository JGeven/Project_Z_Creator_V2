using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z_Creator.DatabaseLayer
{
    public class CharacterDAL : SQLConnect
    {   

        public CharacterDAL()
        {
            Initialize();
        }

        public bool SaveCharacter(CharacterDTO DTO)
        {
            if (OpenConnect())
            {

                cmd.CommandText = "INSERT INTO Characters (name, cost) VALUES(@Name, @Cost)";
                cmd.Parameters.AddWithValue("@Name", DTO.Name);
                cmd.Parameters.AddWithValue("@Cost", DTO.Cost);
                //cmd.Parameters.AddWithValue("@Traits",);
                cmd.ExecuteNonQuery();
                return true;
            }
            else
                return false;
        }

        public List<CharacterDTO> GetCharacters()
        {
            OpenConnect();
            cmd.CommandText = "SELECT * FROM Characters";

            using SqlDataReader rdr = cmd.ExecuteReader();

            List<CharacterDTO> list = new List<CharacterDTO>();

            while (rdr.Read())
            {
                CharacterDTO characters = new CharacterDTO
                {
                    Name = rdr.GetString(0),
                    Cost = rdr.GetInt32(1)
                };
                list.Add(characters);
            }
            CloseConnect();
            return list;
        }

        public int GetCost(CharacterDTO dto)
        {
            OpenConnect();
            CharacterDTO character = new CharacterDTO();
            cmd.CommandText = "SELECT* FROM Characters WHERE Name = '" + dto + "'";


            using SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                character.Cost = Convert.ToInt32(rdr["Cost"].ToString());
            }
            CloseConnect();
            return character.Cost;

   
        }
    }
}
