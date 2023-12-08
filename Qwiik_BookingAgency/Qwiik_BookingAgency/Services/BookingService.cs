using Qwiik_BookingAgency.DataServices;
using Qwiik_BookingAgency.Models;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.Services
{
    /// <summary>
    /// Business Class for the Booking Service
    /// </summary>
    public class BookingService : IBookingService
    {
        private ILogger<BookingService> _logger;
        private IBookingDataService _bookingDataService;
        private ICustomerDataService _customerDataService;

        /// <summary>
        /// Constructor Class
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="bookingDataService"></param>
        /// <param name="customerDataService"></param>
        public BookingService(ILogger<BookingService> logger, IBookingDataService bookingDataService, ICustomerDataService customerDataService)
        {
            _logger = logger;
            _bookingDataService = bookingDataService;
            _customerDataService = customerDataService;
        }

        /// <summary>
        /// Method to book the appointment
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Return the token</returns>
        public async Task<string> BookAppointment(DateTime date)
        {
            Customer newCustomer = new Customer()
            {
                Id = Guid.NewGuid(),
                BookingDate = date
            };

            Booking? result = await _bookingDataService.GetBooking(date.Date);
            if (result == null)
            {
                Booking newSchedule = new Booking()
                {
                    Id = Guid.NewGuid(),
                    CustomerLists = new List<string>(),
                    BookingDate = date.Date,
                };

                newSchedule.BookedAppointment = 1;
                newSchedule.CustomerLists.Add(newCustomer.Id.ToString());
                await _bookingDataService.InsertBooking(newSchedule);
            }
            else
            {
                Booking updatedSchedule = new Booking(result);
                updatedSchedule.BookedAppointment = result.BookedAppointment + 1;
                if (updatedSchedule.CustomerLists == null)
                {
                    updatedSchedule.CustomerLists = new List<string>();
                }
                else if (result.CustomerLists != null)
                {
                    updatedSchedule.CustomerLists = new List<string>(result.CustomerLists);
                }
                updatedSchedule.CustomerLists.Add(newCustomer.Id.ToString());

                if (result.Rules != null)
                {
                    if (result.Rules.isHoliday)
                    {
                        _logger.LogInformation($"Date:{date} is holiday");
                        return await BookAppointment(date.AddDays(1));
                    }
                    else if (result.BookedAppointment >= result.Rules.MaxAppointment)
                    {
                        _logger.LogInformation($"Date:{date} have reached maximum appointment at {result.BookedAppointment}");
                        return await BookAppointment(date.AddDays(1));
                    }
                    else
                    {
                        await _bookingDataService.UpdateBooking(updatedSchedule);
                    }
                }
                else
                {
                    await _bookingDataService.UpdateBooking(updatedSchedule);
                }
            }

            await _customerDataService.InsertCustomer(newCustomer);
            return newCustomer.Id.ToString();
        }

        /// <summary>
        /// Method to list the appointment schedule on that specific date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Return the list of appointment on that date</returns>
        public async Task<ScheduledAppointment> GetAppointmentSchedule(DateTime date)
        {
            ScheduledAppointment appointmentList = new ScheduledAppointment()
            {
                Customers = new List<ScheduledAppointment.CustomerData>()
            };
            var result = await _bookingDataService.GetBooking(date);

            if (result != null)
            {
                appointmentList.BookingDate = result.BookingDate;
                if (result.CustomerLists != null)
                {
                    foreach (var customer in result.CustomerLists)
                    {
                        DateTime customerAppointmentTime = new DateTime();

                        try
                        {
                            _logger.LogInformation($"Trying to get the customer info. Id:{customer}");
                            Customer? customerData = await _customerDataService.GetCustomer(new Guid(customer));
                            _logger.LogInformation($"Customer info retrieved");
                            if (customerData != null)
                            {
                                customerAppointmentTime = customerData.BookingDate;
                            }
                        }
                        catch
                        {
                            _logger.LogInformation($"Failed to get the customer info");
                        }

                        appointmentList.Customers.Add(new ScheduledAppointment.CustomerData()
                        {
                            Token = customer,
                            AppointmentTime = customerAppointmentTime
                        });
                    }
                }
            }

            return appointmentList;
        }

        /// <summary>
        /// Method to set the booking rules for certain date
        /// </summary>
        /// <param name="bookingDate"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public async Task<int> SetBookingRules(DateTime bookingDate, Rules rules)
        {
            try
            {
                var result = await _bookingDataService.GetBooking(bookingDate);

                if (result == null)
                {
                    Booking newSchedule = new Booking()
                    {
                        Id = Guid.NewGuid(),
                        BookingDate = bookingDate,
                        BookedAppointment = 0,
                        CustomerLists = null,
                        Rules = rules
                    };

                    await _bookingDataService.InsertBooking(newSchedule);
                    return 1;
                }
                else
                {
                    Booking updatedSchedule = result;
                    updatedSchedule.Rules = rules;

                    await _bookingDataService.UpdateBooking(updatedSchedule);
                    return 1;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception ",ex);
                return -1;
            }
        }
    }
}
