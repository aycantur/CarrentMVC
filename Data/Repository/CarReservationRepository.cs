using CarRental.Data.Context;
using CarRental.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace CarRental.Data.Repository
{
    public class CarReservationRepository : ICarReservationRepository
    {
        private CarContext carContext;

        public CarReservationRepository(CarContext carContext)
        {
            this.carContext = carContext;
        }
        public void AddReservation(CarReservation carReservation)
        {
            carReservation.RecordDate = DateTime.Now;
            carReservation.RecordStatus = 1;
            carContext.Add(carReservation);
            carContext.SaveChanges();
        }

        public async Task<List<CarReservation>> GetAllAsync()
        {
            return await carContext.CarReservation.ToListAsync() ;
        }

        public async Task<ReservationIn> GetAllResDataAsync()
        {
            
            UserRepository userRepository = new UserRepository(carContext);
            CarsRepository carsRepository = new CarsRepository(carContext);
            CarParRepository carParRepository = new CarParRepository(carContext);
            ReservationIn reservation = new ReservationIn();
            reservation.users = userRepository.GetUsersAsync().Result;
            reservation.Cars= carsRepository.GetAllAsync().Result;
            reservation.carPars = carParRepository.GetCarParsAsync().Result;
            return reservation;
        }

        public async Task<List<ReservationIn>> GetAllReservationDataAsync()
        {
            List<ReservationIn> reservationIns = new List<ReservationIn>();
            ReservationIn reservation1 = new ReservationIn();
            CarReservationRepository carReservationRepository = new CarReservationRepository(carContext);
            var d = carReservationRepository.GetAllAsync().Result.Where(x=>x.RecordStatus==1);
            reservation1 = GetAllResDataAsync().Result;

            foreach (var item in d)
            {
                ReservationIn reservation = new ReservationIn();
                reservation.CarId = item.CarId;
                reservation.Cars = reservation1.Cars.Where(x=>x.Id==item.CarId).ToList();
                int cart = reservation.Cars.FirstOrDefault().CarType;
                int caret = reservation.Cars.FirstOrDefault().EngineType;
                reservation.carPars = reservation1.carPars.Where(x => x.Id == cart||x.Id== caret).ToList();
                reservation.Id = item.Id;
                reservation.Price = item.Price;
                reservation.RecordDate = item.RecordDate;
                reservation.ReservationEndDate = item.ReservationEndDate;
                reservation.ReservationStartDate = item.ReservationStartDate;
                reservation.UserId = item.UserId;
                reservation.users = reservation1.users.Where(x=>x.Id==item.UserId).ToList();
                reservation.RecordStatus = item.RecordStatus;
                reservation.DayCount = item.DayCount;
                reservationIns.Add(reservation);
            }
            var e = reservationIns;

            return e;
        }

        public List<CarReservation> GetCarReservationById(int Id)
        {
            return carContext.CarReservation.Where(x => x.Id == Id).ToList();
        }

        public List<CarReservation> GetCarReservations()
        {
            return carContext.CarReservation.Where(x => x.RecordStatus == 1).ToList();
        }

        public void UpdateReservation(CarReservation carReservation)
        {
            carReservation.RecordDate = DateTime.Now;
            carContext.Update(carReservation);
            carContext.SaveChanges();
        }
    }
}
