using System.ComponentModel.DataAnnotations;

namespace Qwiik_BookingAgency.Models
{
    /// <summary>
    /// Data model for Customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer ID (Token)
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Booking date
        /// </summary>
        public DateTime BookingDate { get; set; }
    }
}
