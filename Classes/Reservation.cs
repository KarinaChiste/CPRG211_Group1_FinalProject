using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Classes
{
    public class Reservation
    {
        public string Name { get; set; }
        public string GroupSize { get; set; }
        public string Time {  get; set; }
        public string Date { get; set; }
        public string ReservationID { get; set; }

        public Reservation(string reservationID, string name, string groupSize, string date, string time)
        {
            ReservationID = reservationID;
            Name = name;
            GroupSize = groupSize;
            Date = date;
            Time = time;

        }

        public override string ToString()
        {
            return $"{ReservationID}, {Name}, Group Size: {GroupSize}, {Date}, {Time}";
        }
    }
}
