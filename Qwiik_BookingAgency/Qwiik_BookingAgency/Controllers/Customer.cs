using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qwiik_BookingAgency.Services;

namespace Qwiik_BookingAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer : ControllerBase
    {
        IBookingService _bookingService;
        ILogger<Customer> _logger;

        public Customer(IBookingService bookingService, ILogger<Customer> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint for customer to book for appointment
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Returns the token (id) given to the customer</returns>
        [HttpPost("BookAppointment/{date:datetime}")]
        public async Task<string> BookAppointment(DateTime date)
        {
            String result = await _bookingService.BookAppointment(date);
            return result;
        }
    }
}
