using CarRental.Data.Context;
using CarRental.Data.Entity;
using CarRental.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarRental.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class CarReservationController : Controller
    {
        private CarReservationRepository carReservationRepository;
        private CarContext carContext;
        private CarsRepository carsRepository;
        private UserRepository userRepository;
        private CarParRepository carParRepository;
        private Tools tools;
        public CarReservationController()
        {
            carContext = new();
            carsRepository = new(carContext);
            carParRepository = new(carContext);
            userRepository = new(carContext);
            carReservationRepository = new(carContext);
        }


        //[HttpGet]
        public IActionResult Index()
        {

            List<ReservationIn> reservationIns = new List<ReservationIn>();
            var a = carReservationRepository.GetCarReservations();
            List<CarReservation> carReservations = new List<CarReservation>();
            var b = carsRepository.GetAllCars();
            var c = userRepository.GetUsersAll();
            ViewBag.ab = userRepository.GetUsersAll();
            foreach (var item in a)
            {
                carContext = new();
                ReservationIn ReservationIn = new ReservationIn();

                ReservationIn.users = c;
                ReservationIn.Cars = b;
                ReservationIn.Id = item.Id;
                ReservationIn.carPars = carParRepository.GetCarParById(b.Select(x => x.CarType).First()).Where(x => x.Type == 1).ToList();
                ReservationIn.carparengine = carParRepository.GetCarParById(b.Select(x => x.EngineType).First()).Where(x => x.Type == 2).ToList();
                ReservationIn.CarId = item.CarId;
                ReservationIn.Price = item.Price;
                ReservationIn.RecordDate = item.RecordDate;
                ReservationIn.RecordStatus = item.RecordStatus;
                ReservationIn.ReservationEndDate = item.ReservationEndDate;
                ReservationIn.ReservationStartDate = item.ReservationStartDate;
                ReservationIn.UserId = item.UserId;
                ReservationIn.DayCount = item.DayCount;
                ReservationIn.name = c.Where(x => x.Id == item.UserId).Select(x => x.Name).First();
                ReservationIn.surname = c.Where(x => x.Id == item.UserId).Select(x => x.Lastname).First();
                reservationIns.Add(ReservationIn);
            }


            return View(reservationIns);
        }

        public IActionResult InsertReservation()
        {

            List<ReservationIn> reservationIns = new List<ReservationIn>();
            ReservationIn reservation = new ReservationIn();
            List<CarsList> carsLists = new List<CarsList>();
            List<Users> userss = new List<Users>();

            var a = userRepository.GetUsers();
            reservation.users = a.ToList();
            ViewBag.users = userRepository.GetUsers();
            ViewBag.Alert = "Araç Müsait Değil";
            var b = carsRepository.GetCars();
            var c = carParRepository.GetCarPars();
            foreach (var item in b)
            {

                CarsList carsList = new CarsList();
                carsList.Id = item.Id;
                carsList.Name = item.Name;
                carsList.Price = item.Price;
                carsList.EngineVolume = item.EngineVolume;
                carsList.CarTypeName = c.Where(x => x.Id == item.CarType).Select(x => x.Name).First();
                carsList.EngineTypeName = c.Where(x => x.Id == item.EngineType).Select(x => x.Name).First();
                carsLists.Add(carsList);
            }
            reservation.Carlist = carsLists;

            return View(reservation);
        }
        public IActionResult InsertReservationContent(ReservationIn reservationIn)
        {

            CarReservation carReservation = new CarReservation();
            carReservation.CarId = reservationIn.CarId;
            carReservation.ReservationStartDate = reservationIn.ReservationStartDate;
            carReservation.ReservationEndDate = reservationIn.ReservationEndDate;
            tools = new();
            if (tools.CarSuitable(reservationIn))
            {
                ViewBag.Alert = "Araç Müsait Değil";
            }
            else
            {

                carReservation.UserId = reservationIn.UserId;
                var a = carsRepository.GetCarById(reservationIn.CarId).ToList();


                if (reservationIn.ReservationEndDate.Year == reservationIn.ReservationStartDate.Year)
                {
                    carReservation.DayCount = reservationIn.ReservationEndDate.DayOfYear - reservationIn.ReservationStartDate.DayOfYear;
                }
                else if (reservationIn.ReservationEndDate.Year > reservationIn.ReservationStartDate.Year)
                {
                    carReservation.DayCount = (reservationIn.ReservationEndDate.Year - reservationIn.ReservationStartDate.Year) * 365;
                    carReservation.DayCount = carReservation.DayCount - (reservationIn.ReservationEndDate.DayOfYear - reservationIn.ReservationStartDate.DayOfYear);

                }

                carReservation.Price = a.Where(x => x.Id == reservationIn.CarId).Select(x => x.Price).First() * carReservation.DayCount;
                carReservationRepository.AddReservation(carReservation);
                View("Index", "Popup");
                ViewBag.message = "Kayıt işlemi başarılıdır.";

            }
            return RedirectToAction("Index");
        }
        public IActionResult CancelReservation(int Id)
        {
            CarReservation reservation = new CarReservation();
            reservation = carReservationRepository.GetCarReservationById(Id).First();

            reservation.RecordStatus = 2;
            carReservationRepository.UpdateReservation(reservation);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateReservation(int Id)
        {
            ReservationIn reservation = new ReservationIn();
            if (Id!=0)
            {
                List<ReservationIn> reservationIns = new List<ReservationIn>();
                
                List<CarsList> carsLists = new List<CarsList>();
                List<Users> userss = new List<Users>();
                CarReservation carreservation = new CarReservation();
                carreservation = carReservationRepository.GetCarReservationById(Id).First();
                var a = userRepository.GetUsers();
                reservation.users = a.ToList();
                reservation.Id = carreservation.Id;
                reservation.Price = carreservation.Price;
                reservation.RecordStatus = 1;
                reservation.ReservationEndDate = carreservation.ReservationEndDate;
                reservation.ReservationStartDate = carreservation.ReservationStartDate;
                reservation.UserId = carreservation.UserId;
                reservation.CarId = carreservation.CarId;
                var b = carsRepository.GetCars();
                var c = carParRepository.GetCarPars();

                foreach (var item in b)
                {

                    CarsList carsList = new CarsList();
                    carsList.Id = item.Id;
                    carsList.Name = item.Name;
                    carsList.Price = item.Price;
                    carsList.EngineVolume = item.EngineVolume;
                    carsList.CarTypeName = c.Where(x => x.Id == item.CarType).Select(x => x.Name).First();
                    carsList.EngineTypeName = c.Where(x => x.Id == item.EngineType).Select(x => x.Name).First();
                    carsLists.Add(carsList);
                }
                reservation.Carlist = carsLists;
            }
            

            return View(reservation);
        }
        public IActionResult UpdateReservationContent(ReservationIn reservationIn)
        {
            CarReservation carReservation = new CarReservation();
            carReservation.Id = reservationIn.Id;
            carReservation.CarId = reservationIn.CarId;
            carReservation.RecordStatus = 1;
            carReservation.UserId = reservationIn.UserId;
            var a = carsRepository.GetCarById(reservationIn.CarId).ToList();

            carReservation.ReservationStartDate = reservationIn.ReservationStartDate;
            carReservation.ReservationEndDate = reservationIn.ReservationEndDate;
            tools = new();
            if (tools.CarSuitable(reservationIn))
            {
                ViewBag.Alert = "Araç Müsait Değil";
            }
            else
            {
                if (reservationIn.ReservationEndDate.Year == reservationIn.ReservationStartDate.Year)
                {
                    carReservation.DayCount = reservationIn.ReservationEndDate.DayOfYear - reservationIn.ReservationStartDate.DayOfYear;
                }
                else if (reservationIn.ReservationEndDate.Year > reservationIn.ReservationStartDate.Year)
                {
                    carReservation.DayCount = (reservationIn.ReservationEndDate.Year - reservationIn.ReservationStartDate.Year) * 365;
                    if (carReservation.DayCount == 365)
                    {
                        carReservation.DayCount = (reservationIn.ReservationEndDate.DayOfYear + (365 - reservationIn.ReservationStartDate.DayOfYear));
                    }
                    else
                    {
                        carReservation.DayCount = carReservation.DayCount + reservationIn.ReservationEndDate.DayOfYear - reservationIn.ReservationStartDate.DayOfYear;
                    }
                }

                carReservation.Price = a.Where(x => x.Id == reservationIn.CarId).Select(x => x.Price).First() * carReservation.DayCount;
                carReservationRepository.UpdateReservation(carReservation);
            }
            return RedirectToAction("Index");
        }
    }
}
