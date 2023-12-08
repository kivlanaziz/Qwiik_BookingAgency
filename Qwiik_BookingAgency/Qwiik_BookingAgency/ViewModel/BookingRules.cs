using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.ViewModel
{
    /// <summary>
    /// View Model Class for the Booking Rules
    /// </summary>
    public class BookingRules
    {
        /// <summary>
        /// Booking Date
        /// </summary>
        /// <example>2023-12-07</example>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// Rules Class
        /// </summary>
        public Rules Rules { get; set; }
    }
}
