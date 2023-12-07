using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    public class CustomerDataService : ICustomerDataService
    {
        public ILogger<CustomerDataService> _logger;

        public CustomerDataService(ILogger<CustomerDataService> logger)
        {
            _logger = logger;
        }

        public void DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Booking customer)
        {
            throw new NotImplementedException();
        }
    }
}
