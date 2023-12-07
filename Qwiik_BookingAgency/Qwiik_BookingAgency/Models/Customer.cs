namespace Qwiik_BookingAgency.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
