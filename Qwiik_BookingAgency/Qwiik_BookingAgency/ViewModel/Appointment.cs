namespace Qwiik_BookingAgency.ViewModel
{
    public class Appointment
    {
        public class CustomerData
        {
            string Name { get; set; }
            string Token { get; set; }
        }
        public DateTime BookingDate { get; set; }
        public List<CustomerData>? Customers { get; set; }
    }
}
