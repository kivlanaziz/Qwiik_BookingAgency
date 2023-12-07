using Qwiik_BookingAgency.Models;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.Services
{
    public class BookingService : IBookingService
    {
        private ILogger<BookingService> _logger;

        public BookingService(ILogger<BookingService> logger)
        {
            _logger = logger;
        }

        public Guid BookAppointment(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentSchedule(DateTime date)
        {
            throw new NotImplementedException();
        }

        public int SetBookingRules(DateTime bookingDate, Rules rules)
        {
            throw new NotImplementedException();
        }
    }
}
