using Qwiik_BookingAgency.DataServices;
using Qwiik_BookingAgency.Models;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.Services
{
    public class BookingService : IBookingService
    {
        private ILogger<BookingService> _logger;
        private IBookingDataService _bookingDataService;

        public BookingService(ILogger<BookingService> logger, IBookingDataService bookingDataService)
        {
            _logger = logger;
            _bookingDataService = bookingDataService;
        }

        public async Task<string> BookAppointment(DateTime date)
        {
            
            Customer newCustomer = new Customer()
            {
                Id = Guid.NewGuid(),
                BookingDate = date
            };

            var result = await _bookingDataService.GetBooking(date);
            if (result == null)
            {
                Booking newSchedule = new Booking()
                {
                    Id = Guid.NewGuid(),
                    CustomerLists = new List<string>(),
                    BookingDate = date,
                };

                newSchedule.BookedAppointment = 1;
                newSchedule.CustomerLists.Add(newCustomer.Id.ToString());
                await _bookingDataService.InsertBooking(newSchedule);
            }
            else
            {
                Booking updatedSchedule = result;
                updatedSchedule.BookedAppointment = result.BookedAppointment + 1;
                if (updatedSchedule.CustomerLists == null)
                {
                    updatedSchedule.CustomerLists = new List<string>();
                }
                else if (result.CustomerLists != null)
                {
                    updatedSchedule.CustomerLists = result.CustomerLists;
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
            return newCustomer.Id.ToString();
        }

        public async Task<Appointment> GetAppointmentSchedule(DateTime date)
        {
            Appointment appointmentList = new Appointment()
            {
                Customers = new List<Appointment.CustomerData>()
            };
            var result = await _bookingDataService.GetBooking(date);

            if (result != null)
            {
                appointmentList.BookingDate = result.BookingDate;
                if (result.CustomerLists != null)
                {
                    foreach (var customer in result.CustomerLists)
                    {
                        appointmentList.Customers.Add(new Appointment.CustomerData()
                        {
                            Token = customer
                        });
                    }
                }
            }

            return appointmentList;
        }

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
