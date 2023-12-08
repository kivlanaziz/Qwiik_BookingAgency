using Microsoft.EntityFrameworkCore;
using Qwiik_BookingAgency.Context;
using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    /// <summary>
    /// Data Layer Class to interract with the Customer Collections
    /// </summary>
    public class CustomerDataService : ICustomerDataService
    {
        private ILogger<CustomerDataService> _logger;
        private BookingDbContext _bookingDb;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="bookingDb"></param>
        public CustomerDataService(ILogger<CustomerDataService> logger, BookingDbContext bookingDb)
        {
            _logger = logger;
            _bookingDb = bookingDb;
        }

        /// <summary>
        /// Delete Customer from DB
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve all data
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Customer?> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve specific customer data based on the customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer?> GetCustomer(Guid customerId)
        {
            if (_bookingDb.Customer != null)
            {
                return await _bookingDb.Customer.Where(x => x.Id == customerId).FirstOrDefaultAsync();
            }
            return null;
        }

        /// <summary>
        /// Insert Customer data into the DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task InsertCustomer(Customer customer)
        {
            _bookingDb.Customer?.Add(customer);
            await _bookingDb.SaveChangesAsync();
        }

        /// <summary>
        /// Update existing Customer data
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UpdateCustomer(Booking customer)
        {
            throw new NotImplementedException();
        }
    }
}
