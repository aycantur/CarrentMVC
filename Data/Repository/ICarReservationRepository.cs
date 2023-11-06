using CarRental.Data.Entity;

namespace CarRental.Data.Repository
{
    public interface ICarReservationRepository
    {
        void AddReservation (CarReservation carReservation);
        void UpdateReservation(CarReservation carReservation);
       
        List<CarReservation> GetCarReservationById(int Id);

        List<CarReservation> GetCarReservations ();
        public Task<List<CarReservation>> GetAllAsync();

        public Task<ReservationIn> GetAllResDataAsync();

        public Task<List<ReservationIn>> GetAllReservationDataAsync();

    }
}
