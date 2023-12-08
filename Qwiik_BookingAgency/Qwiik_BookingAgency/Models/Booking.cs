using System.ComponentModel.DataAnnotations;

namespace Qwiik_BookingAgency.Models
{
    /// <summary>
    /// Data Model for Booking Class
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Booking ID
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Booking Date
        /// </summary>
        public DateTime BookingDate { get; set; }
        /// <summary>
        /// Rules for the booking at the specific date
        /// </summary>
        public Rules? Rules { get; set; }
        /// <summary>
        /// Number of booked appointment at this specific date
        /// </summary>
        public int BookedAppointment { get; set; }
        /// <summary>
        /// List of registered customer at this specific date
        /// </summary>
        public List<string>? CustomerLists { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Booking() { }

        /// <summary>
        /// Constructor method to copy the value
        /// </summary>
        /// <param name="other"></param>
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
