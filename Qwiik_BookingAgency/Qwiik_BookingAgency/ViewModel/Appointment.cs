namespace Qwiik_BookingAgency.ViewModel
{
    public class Appointment
    {
        public class CustomerData
        {
            public string Name { get; set; }
            public string Token { get; set; }
        }
        public DateTime BookingDate { get; set; }
        public List<CustomerData>? Customers { get; set; }
    }
}
