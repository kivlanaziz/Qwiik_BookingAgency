namespace Qwiik_BookingAgency.Models
{
    /// <summary>
    /// Rule class to define the parameter of the rules.
    /// </summary>
    public class Rules
    {
        /// <summary>
        /// Rule to mark if it is holiday
        /// </summary>
        public bool isHoliday { get; set; }
        /// <summary>
        /// Rule to set the max number of appointment
        /// </summary>
        public int? MaxAppointment { get; set; }
    }
}
