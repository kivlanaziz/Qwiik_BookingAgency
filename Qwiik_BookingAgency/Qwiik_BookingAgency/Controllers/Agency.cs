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

        public Agency(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetAppointmentList/{date:datetime}")]
        public async Task<Appointment> GetAppointmentList(DateTime date)
        {
            return await _bookingService.GetAppointmentSchedule(date.Date);
        }

        [HttpPost("SetBookingRules/{date:datetime}")]
        public async Task<IActionResult> SetBookingRule(BookingRules bookingRules)
        {
            int result = await _bookingService.SetBookingRules(bookingRules.bookingDate.Date, bookingRules.rules);
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
