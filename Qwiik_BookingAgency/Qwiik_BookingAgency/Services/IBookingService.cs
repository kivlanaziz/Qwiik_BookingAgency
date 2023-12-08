using Qwiik_BookingAgency.Models;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.Services
{
    /// <summary>
    /// Business Class for the Booking Service
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Method to book the appointment
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Return the token</returns>
        public Task<string> BookAppointment(DateTime date);

        /// <summary>
        /// Method to set the booking rules for certain date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="bookingRules"></param>
        /// <returns></returns>
        public Task<int> SetBookingRules(DateTime date, Rules bookingRules);

        /// <summary>
        /// Method to list the appointment schedule on that specific date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Return the list of appointment on that date</returns>
        public Task<ScheduledAppointment> GetAppointmentSchedule(DateTime date);
    }
}
