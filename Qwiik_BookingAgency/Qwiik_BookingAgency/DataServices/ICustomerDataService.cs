using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    public interface ICustomerDataService
    {
        public Task InsertCustomer(Customer customer);
        public Task UpdateCustomer(Booking customer);
        public Task DeleteCustomer(Guid customerId);
        public IEnumerable<Customer?> GetAll();
        public Task<Customer?> GetCustomer(Guid customerId);
    }
}
