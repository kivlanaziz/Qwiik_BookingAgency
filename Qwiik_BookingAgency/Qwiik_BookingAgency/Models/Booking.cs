namespace Qwiik_BookingAgency.Models
{
    public class Booking
    {
        public DateTime Id { get; set; }
        public Rules? Rules { get; set; }
        public int BookedAppointment { get; set; }
        public List<Guid>? CustomerLists { get; set; }
    }
}
