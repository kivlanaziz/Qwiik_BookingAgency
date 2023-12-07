using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qwiik_BookingAgency.Models;
using Qwiik_BookingAgency.Services;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Agency : ControllerBase
    {
        IBookingService _bookingService;
        ILogger<Agency> _logger;

        public Agency(IBookingService bookingService, ILogger<Agency> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [HttpGet("GetAppointmentList/{date:datetime}")]
        public ActionResult<Appointment> GetAppointmentList(DateTime date)
        {
            return _bookingService.GetAppointmentSchedule(date.Date);
        }

        [HttpPost("SetBookingRules/")]
        public IActionResult SetBookingRule(DateTime date, Rules bookingRules)
        {
            int result = _bookingService.SetBookingRules(date.Date, bookingRules);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
