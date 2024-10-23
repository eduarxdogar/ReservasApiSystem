using System;

namespace ReservationSystem.Core.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Ranking { get; set; } = 0;
        public int RatesCount { get; set; } = 0;
        public bool Favorite { get; set; } = false;
        public string Description { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
