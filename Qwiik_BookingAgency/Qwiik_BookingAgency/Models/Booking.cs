using System.ComponentModel.DataAnnotations;

namespace Qwiik_BookingAgency.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public Rules? Rules { get; set; }
        public int BookedAppointment { get; set; }
        public List<string>? CustomerLists { get; set; }

        public Booking() { }

        public Booking(Booking other)
        {
            BookingDate = other.BookingDate;
            Rules = other.Rules;
            CustomerLists = other.CustomerLists;
            Id = other.Id;
            BookedAppointment = other.BookedAppointment;
        }
    }
}
