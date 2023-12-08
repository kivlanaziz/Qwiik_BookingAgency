namespace Qwiik_BookingAgency.ViewModel
{
    /// <summary>
    /// View Model class for the scheduled appointment, represent the booking date and the customers that have appointment
    /// </summary>
    public class ScheduledAppointment
    {
        /// <summary>
        /// Customer Data Class
        /// </summary>
        public class CustomerData
        {
            /// <summary>
            /// Customer Token
            /// </summary>
            public string Token { get; set; }

            /// <summary>
            /// Assigned Appointment Time
            /// </summary>
            public DateTime AppointmentTime { get; set; }
        }

        /// <summary>
        /// Booking Date
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// List of Customers Data
        /// </summary>
        public List<CustomerData>? Customers { get; set; }
    }
}
