using Microsoft.EntityFrameworkCore;
using Qwiik_BookingAgency.Context;
using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    public class BookingDataService : IBookingDataService
    {
        private ILogger<BookingDataService> _logger;
        private BookingDbContext _bookingDb;

        public BookingDataService(ILogger<BookingDataService> logger, BookingDbContext bookingDb)
        {
            _logger = logger;
            _bookingDb = bookingDb;
        }

        public void DeleteBooking(DateTime bookingDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Booking> GetBooking(DateTime bookingDate)
        {
            if (_bookingDb.Bookings != null)
            {
                return await _bookingDb.Bookings.Where(x => x.BookingDate == bookingDate).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task InsertBooking(Booking booking)
        {
            _bookingDb.Bookings?.Add(booking);
            await _bookingDb.SaveChangesAsync();
        }

        public async Task UpdateBooking(Booking booking)
        {
            if (_bookingDb.Bookings != null)
            {
                var result = await _bookingDb.Bookings.Where(x => x.BookingDate == booking.BookingDate).FirstOrDefaultAsync();

                if (result != null)
                {
                    result.CustomerLists = booking.CustomerLists;
                    result.BookedAppointment = booking.BookedAppointment;
                    result.Rules = booking.Rules;

                    await _bookingDb.SaveChangesAsync();
                    _logger.LogInformation($"Record for Booking Date {booking.BookingDate} has been successfully updated!");
                }
            }
        }
    }
}
