using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qwiik_BookingAgency.Services;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.Controllers
{
    /// <summary>
    /// Controller Class for Customer Endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class Customer : ControllerBase
    {
        IBookingService _bookingService;
        ILogger<Customer> _logger;

        /// <summary>
        /// Constructor for Customer Controller Class
        /// </summary>
        /// <param name="bookingService"></param>
        /// <param name="logger"></param>
        public Customer(IBookingService bookingService, ILogger<Customer> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint for customer to book for appointment
        /// </summary>
        /// <param name="date" example="2023-12-09"></param>
        /// <returns>Returns the customer data</returns>
        [HttpPost("BookAppointment/{date:datetime}")]
        public async Task<CustomerData> BookAppointment(DateTime date)
        {
            CustomerData result = await _bookingService.BookAppointment(date);
            return result;
        }
    }
}
