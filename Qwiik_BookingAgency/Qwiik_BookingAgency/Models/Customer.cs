using System.ComponentModel.DataAnnotations;

namespace Qwiik_BookingAgency.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
