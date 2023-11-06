namespace CarRental.Data.Entity
{
    public class CarReservation
    {
        public int Id{ get; set; }
        public int UserId { get; set; }
        public int CarId{ get; set; }
        public int DayCount{ get; set; }
        public decimal Price { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public DateTime RecordDate { get; set; }
        public int RecordStatus { get; set; }
    }
}
