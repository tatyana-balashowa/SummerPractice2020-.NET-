using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class KindOfSport
    {
        public int idKindOfSport{ get; set;}
        public string nameOfKind { get; set; }

        public override string ToString()
        {
            return $"{idKindOfSport} {nameOfKind}";
        }
    }
}
