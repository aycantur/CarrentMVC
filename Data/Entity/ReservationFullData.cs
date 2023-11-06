namespace CarRental.Data.Entity
{
    public class ReservationFullData:CarsList
    {
        public List<Users> users { get; set; }

        public List<CarReservation> carReservations { get; set; }

        public List<Cars> cars { get; set; }

    }
}
