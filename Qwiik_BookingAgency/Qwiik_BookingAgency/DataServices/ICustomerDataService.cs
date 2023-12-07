using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    public interface ICustomerDataService
    {
        public void InsertCustomer(Customer customer);
        public void UpdateCustomer(Booking customer);
        public void DeleteCustomer(Guid customerId);
        public IEnumerable<Customer> GetAll();
        public IEnumerable<Booking> GetCustomer(Guid customerId);
    }
}
