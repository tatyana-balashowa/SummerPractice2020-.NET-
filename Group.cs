using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Group
    {
        public int idGroup { get; set; }
        public string name { get; set; }
        public int number { get; set; }
        public int workingDay { get; set; }
        public TimeSpan timeToBegin { get; set; }
        public TimeSpan timeToEnd { get; set; }

        public override string ToString()
        {
            return $"{name} {number} {workingDay} {timeToBegin} {timeToEnd}";
        }



    }
}
