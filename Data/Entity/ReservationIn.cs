namespace CarRental.Data.Entity
{
    public class ReservationIn:CarReservation
    {
        public List<CarsList> Carlist{ get; set; }
        public List<Users> users{ get; set; }
        public List<CarPar> carPars{ get; set; }
        public List<CarPar> carparengine{ get; set; }
        public List<Cars> Cars{ get; set; }
        public string carname{ get; set; }
        public string name{ get; set; }
        public string surname{ get; set; }

    }
}
