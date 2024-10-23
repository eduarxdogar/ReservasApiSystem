using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReservationSystem.Core.Models
{
    public class ContactType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
