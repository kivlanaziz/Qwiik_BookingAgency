using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    public interface IBookingDataService
    {
        public void InsertBooking(Booking booking);
        public void UpdateBooking(Booking booking);
        public void DeleteBooking(DateTime bookingDate);
        public IEnumerable<Booking> GetAll();
        public IEnumerable<Booking> GetBooking(DateTime startDate);
    }
}
