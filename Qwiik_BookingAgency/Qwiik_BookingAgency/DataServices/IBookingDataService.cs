using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    public interface IBookingDataService
    {
        public Task InsertBooking(Booking booking);
        public Task UpdateBooking(Booking booking);
        public Task DeleteBooking(DateTime bookingDate);
        public IEnumerable<Booking?> GetAll();
        public Task<Booking?> GetBooking(DateTime bookingDate);
    }
}
