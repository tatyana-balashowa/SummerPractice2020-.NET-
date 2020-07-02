using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Hall
    {
        public int idHall { get; set; }
        public string nameOfHall { get; set; }

        public override string ToString()
        {
            return $"{idHall} {nameOfHall}";
        }
    }
}
