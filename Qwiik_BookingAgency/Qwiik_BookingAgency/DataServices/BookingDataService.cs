using Microsoft.EntityFrameworkCore;
using Qwiik_BookingAgency.Context;
using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    /// <summary>
    /// Data Layer Class to interract with the Booking Collections
    /// </summary>
    public class BookingDataService : IBookingDataService
    {
        private ILogger<BookingDataService> _logger;
        private BookingDbContext _bookingDb;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="bookingDb"></param>
        public BookingDataService(ILogger<BookingDataService> logger, BookingDbContext bookingDb)
        {
            _logger = logger;
            _bookingDb = bookingDb;
        }

        /// <summary>
        /// Delete Booking Method
        /// </summary>
        /// <param name="bookingDate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteBooking(DateTime bookingDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve all data
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Booking?> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve specific booking data based on the booking date
        /// </summary>
        /// <param name="bookingDate"></param>
        /// <returns></returns>
        public async Task<Booking?> GetBooking(DateTime bookingDate)
        {
            if (_bookingDb.Bookings != null)
            {
                return await _bookingDb.Bookings.Where(x => x.BookingDate == bookingDate).FirstOrDefaultAsync();
            }
            return null;
        }

        /// <summary>
        /// Insert booking data into the DB
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public async Task InsertBooking(Booking booking)
        {
            _bookingDb.Bookings?.Add(booking);
            await _bookingDb.SaveChangesAsync();
        }

        /// <summary>
        /// Update existing Booking data
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
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
