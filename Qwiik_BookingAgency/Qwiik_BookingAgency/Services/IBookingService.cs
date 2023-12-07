using Qwiik_BookingAgency.Models;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.Services
{
    public interface IBookingService
    {
        public Task<string> BookAppointment(DateTime date);
        public Task<int> SetBookingRules(DateTime date, Rules bookingRules);
        public Task<ScheduledAppointment> GetAppointmentSchedule(DateTime date);
    }
}
