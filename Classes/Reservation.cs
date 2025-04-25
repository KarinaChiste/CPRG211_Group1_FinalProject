using System;
using CPRG211_Group1_FinalProject.Exceptions;

namespace CPRG211_Group1_FinalProject.Classes
{
    //Creates reservation objects and validates the inputs
    public class Reservation
    {
        private string reservationId;
        private string name;
        private string groupSize;
        private string date;
        private string time;

        public string ReservationId
        {
            get => reservationId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Reservation ID");
                }

                if (!int.TryParse(value, out int parsedId))
                {
                    throw new InvalidFormatException("Reservation ID must be a numeric value.");
                }

                if (parsedId < 0)
                {
                    throw new InvalidFormatException("Reservation ID cannot be negative.");
                }

                if (value.Length != 6)
                {
                    throw new InvalidFormatException("Reservation ID must be exactly 6 digits long.");
                }
                reservationId = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Name");
                }
                name = value;
            }
        }

        public string GroupSize
        {
            get => groupSize;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Group Size");
                }
                groupSize = value;
            }
        }

        public string Date
        {
            get => date;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Date");
                }
                date = value;
            }
        }

        public string Time
        {
            get => time;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Time");
                }
                time = value;
            }
        }

        public Reservation(string reservationId, string name, string groupSize, string date, string time)
        {
            ReservationId = reservationId;
            Name = name;
            GroupSize = groupSize;
            Date = date;
            Time = time;
        }

        public override string ToString()
        {
            return $"{ReservationId}, {Name}, {GroupSize}, {Date}, {Time}";
        }
    }
}
