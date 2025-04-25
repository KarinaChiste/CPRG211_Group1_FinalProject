using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Icu.Text.Transliterator;
//using static Android.Net.Wifi.WifiEnterpriseConfig;

namespace CPRG211_Group1_FinalProject.Classes
{
    //creates reservations
    class ReservationManager
    {
        public static List<Reservation> reservations = new List<Reservation>();

        public static List<Reservation> GetReservations()
        {
            return reservations;
        }

        public static Reservation makeReservation(string reservationID, string name, string groupSize, string date, string time)
        {
            Reservation res = null;
            res = new Reservation(reservationID, name, groupSize, date, time);
            reservations.Add(res);

            ReservationDbAccessor db = new ReservationDbAccessor();
            db.AddReservation(res);
            return res;
        }

        public static void DeleteReservation(string reservationId)
        {
            ReservationDbAccessor db = new ReservationDbAccessor();
            db.RemoveReservation(reservationId);
        }
    }
}
