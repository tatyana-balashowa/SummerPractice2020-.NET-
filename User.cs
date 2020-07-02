using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int idUser { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telephoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string login { get; set; }
        public int passwordHashCode { get; set; }

        public override string ToString()
        {
            return $"{idUser} {firstName} {lastName} {telephoneNumber} {emailAddress} {login} {passwordHashCode} ";
        }

    }
}
