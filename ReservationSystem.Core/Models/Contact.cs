using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReservationSystem.Core.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
    }
}
