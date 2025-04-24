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

        public Reservation(string name, string groupSize, string time, string date, string reservationID)
        {
            Name = name;
            GroupSize = groupSize;
            Time = time;
            Date = date;
            ReservationID = reservationID;

        }

        public override string ToString()
        {
            return $"{Name}, Group Size: {GroupSize}, {Time}, {Date}, {ReservationID}";
        }
    }
}
