using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Z_Creator.DatabaseLayer;

namespace Project_Z_Creator.LogicLayer
{
    internal class OccupationContainer
    {


        public List<Occupations> GetOccupations()
        {
            List<Occupations> Occupations = new List<Occupations>();
            OccupationDAL dal = new OccupationDAL();
            List<OccupationDTO> list = dal.GetOccupations();
            foreach (OccupationDTO occupations in list)
            {
                Occupations newoccupation = new Occupations(occupations);
                Occupations.Add(newoccupation);
            }
            return Occupations;
        }

    }
}
