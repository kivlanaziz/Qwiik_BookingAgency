using Microsoft.Extensions.Logging;
using Moq;
using Qwiik_BookingAgency.DataServices;
using Qwiik_BookingAgency.Models;
using Qwiik_BookingAgency.Services;
using Qwiik_BookingAgency.ViewModel;

namespace Qwiik_BookingAgency.UnitTest
{
    public class Tests
    {
        private Mock<ILogger<BookingService>> _mockLogger = new Mock<ILogger<BookingService>>();
        private Mock<IBookingDataService> _mockBookingDataService = new Mock<IBookingDataService>();
        private Mock<ICustomerDataService> _mockCustomerDataService = new Mock<ICustomerDataService>();

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task GetAppointmentSchedule_Success()
        {
            DateTime inputData = new DateTime(2023, 12, 7);
            Booking resultMock = new Booking()
            {
                BookingDate = new DateTime(2023, 12, 7),
                Id = new Guid(),
                BookedAppointment = 3,
                CustomerLists = new List<string>()
                {
                    "1",
                    "2",
                    "3"
                }
            };
            ScheduledAppointment expectedResult = new ScheduledAppointment()
            {
                BookingDate = new DateTime(2023, 12, 7),
                Customers = new List<ScheduledAppointment.CustomerData>()
            };

            for (int i=1; i<=3; i++)
            {
                var customer = new ScheduledAppointment.CustomerData();
                customer.Token = i.ToString();
                expectedResult.Customers.Add(customer);
            }

            _mockBookingDataService.Setup(x => x.GetBooking(inputData)).ReturnsAsync(resultMock);

            var BookingService = new BookingService(_mockLogger.Object, _mockBookingDataService.Object, _mockCustomerDataService.Object);
            
            var testResult = await BookingService.GetAppointmentSchedule(inputData);

            AreEqualByJson(expectedResult, testResult);
        }

        public static void AreEqualByJson(object expected, object actual)
        {
            var expectedJson = Newtonsoft.Json.JsonConvert.SerializeObject(expected);
            var actualJson = Newtonsoft.Json.JsonConvert.SerializeObject(actual);
            Assert.That(actualJson, Is.EqualTo(expectedJson));
        }
    }
}