using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Classes
{
    public class Reservation
    {
        public string Name { get; set; }
        public string GroupSize { get; set; }
        public string Time {  get; set; }

        public Reservation(string name, string groupSize, string time)
        {
            Name = name;
            GroupSize = groupSize;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Name}, Group Size: {GroupSize}, {Time}";
        }
    }
}
