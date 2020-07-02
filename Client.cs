using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Client
    {

        public int idClient { get; set; }
        public string firstName { get; set;}
        public string lastName { get; set; }
        public string telephoneNumber { get; set; }
        public int idfavoriteCoach { get; set; }

        public override string ToString()
        {
            return $"{idClient} {firstName} {lastName} {telephoneNumber} {idfavoriteCoach}";
        }

    }
}
