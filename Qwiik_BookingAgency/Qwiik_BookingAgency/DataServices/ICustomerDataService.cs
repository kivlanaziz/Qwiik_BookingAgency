using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.DataServices
{
    /// <summary>
    /// Data Layer Class to interract with the Customer Collections
    /// </summary>
    public interface ICustomerDataService
    {
        /// <summary>
        /// Insert Customer data into the DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Task InsertCustomer(Customer customer);

        /// <summary>
        /// Update existing Customer data
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Task UpdateCustomer(Booking customer);

        /// <summary>
        /// Delete Customer from DB
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Task DeleteCustomer(Guid customerId);

        /// <summary>
        /// Retrieve all data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer?> GetAll();

        /// <summary>
        /// Retrieve specific customer data based on the customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Task<Customer?> GetCustomer(Guid customerId);
    }
}
