namespace Qwiik_BookingAgency.ViewModel
{
    public class ScheduledAppointment
    {
        public class CustomerData
        {
            public string Token { get; set; }
            public DateTime AppointmentTime { get; set; }
        }
        public DateTime BookingDate { get; set; }
        public List<CustomerData>? Customers { get; set; }
    }
}
