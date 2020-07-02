using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Coach
    {
        public int idCoach { get; set;}
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telephoneNumber { get; set; }
        public int mainHall { get; set; }

        public override string ToString()
        {
            return $" {idCoach} {firstName} {lastName} {telephoneNumber} {mainHall}";
        }


    }
}
