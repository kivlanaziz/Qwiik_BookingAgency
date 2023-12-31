﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qwiik_BookingAgency.Models;
using Qwiik_BookingAgency.Services;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.Controllers
{
    /// <summary>
    /// Controller Class for Agency Endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class Agency : ControllerBase
    {
        IBookingService _bookingService;

        /// <summary>
        /// Constructor for Agency Controller Class
        /// </summary>
        /// <param name="bookingService"></param>
        public Agency(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// The endpoint to get the list of customer having appointment at certain day.
        /// </summary>
        /// <param name="date" example="2023-12-08"></param>
        /// <returns>Return the list of customers at certain day</returns>
        [HttpGet("GetAppointmentList/{date:datetime}")]
        public async Task<ScheduledAppointment> GetAppointmentList(DateTime date)
        {
            return await _bookingService.GetAppointmentSchedule(date.Date);
        }

        /// <summary>
        /// Set the rules for certain day, the objective is so the agency can set certain day as holiday or set a max number of customer at certain day.
        /// </summary>
        /// <param name="bookingRules" example="sampleRules"></param>
        /// <returns>Return the status</returns>
        [HttpPost("SetBookingRules/")]
        public async Task<IActionResult> SetBookingRule(BookingRules bookingRules)
        {
            int result = await _bookingService.SetBookingRules(bookingRules.BookingDate.Date, bookingRules.Rules);
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
