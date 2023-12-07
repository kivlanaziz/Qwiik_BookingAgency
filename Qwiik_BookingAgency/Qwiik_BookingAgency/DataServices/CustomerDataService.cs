using Microsoft.EntityFrameworkCore;
using Qwiik_BookingAgency.Context;
using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    public class CustomerDataService : ICustomerDataService
    {
        public ILogger<CustomerDataService> _logger;
        private BookingDbContext _bookingDb;

        public CustomerDataService(ILogger<CustomerDataService> logger, BookingDbContext bookingDb)
        {
            _logger = logger;
            _bookingDb = bookingDb;
        }

        public Task DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer?> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer?> GetCustomer(Guid customerId)
        {
            if (_bookingDb.Customer != null)
            {
                return await _bookingDb.Customer.Where(x => x.Id == customerId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task InsertCustomer(Customer customer)
        {
            _bookingDb.Customer?.Add(customer);
            await _bookingDb.SaveChangesAsync();
        }

        public Task UpdateCustomer(Booking customer)
        {
            throw new NotImplementedException();
        }
    }
}
