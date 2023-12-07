using Qwiik_BookingAgency.Models;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.Services
{
    public interface IBookingService
    {
        public Guid BookAppointment(DateTime date);
        public int SetBookingRules(DateTime date, Rules bookingRules);
        public Appointment GetAppointmentSchedule(DateTime date);
    }
}
