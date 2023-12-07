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

        [HttpPost("BookAppointment/{date:datetime}")]
        public Guid BookAppointment(DateTime date)
        {
            Guid result = _bookingService.BookAppointment(date.Date);
            return result;
        }
    }
}
