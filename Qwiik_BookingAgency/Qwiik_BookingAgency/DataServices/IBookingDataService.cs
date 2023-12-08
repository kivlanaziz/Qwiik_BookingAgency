using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    /// <summary>
    /// Data Layer Class to interract with the Booking Collections
    /// </summary>
    public interface IBookingDataService
    {
        /// <summary>
        /// Insert booking data into the DB
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public Task InsertBooking(Booking booking);

        /// <summary>
        /// Update existing Booking data
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public Task UpdateBooking(Booking booking);

        /// <summary>
        /// Delete Booking Method
        /// </summary>
        /// <param name="bookingDate"></param>
        /// <returns></returns>
        public Task DeleteBooking(DateTime bookingDate);

        /// <summary>
        /// Retrieve all data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Booking?> GetAll();

        /// <summary>
        /// Retrieve specific booking data based on the booking date
        /// </summary>
        /// <param name="bookingDate"></param>
        /// <returns></returns>
        public Task<Booking?> GetBooking(DateTime bookingDate);
    }
}
