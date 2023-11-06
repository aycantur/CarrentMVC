using CarRental.Data.Context;
using CarRental.Data.Entity;
using CarRental.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ValuesController : ControllerBase
    {

        public ValuesController()
        {

        }

        [HttpGet]
        public async Task<ReservationIn> GetAllResDataAsync()
        {
            CarContext carContext = new CarContext();
            CarReservationRepository carReservationRepository = new CarReservationRepository(carContext);

            return await carReservationRepository.GetAllResDataAsync();
        }

        [HttpGet]
        public Task<List<ReservationIn>> GetAllReservationDataAsync()
        {
            CarContext carContext = new CarContext();
            CarReservationRepository carReservationRepository = new CarReservationRepository(carContext);

            return carReservationRepository.GetAllReservationDataAsync();
        }

        [HttpGet]
        public async Task<List<CarReservation>> GetCarReservationDataAsync()
        {
            CarContext carContext = new CarContext();
            CarReservationRepository carReservationRepository = new CarReservationRepository(carContext);
            var a=carReservationRepository.GetCarReservations();
            return  a;
        }


        [HttpGet]
        public async Task<List<Users>> Users()
        {
            CarContext carContext = new CarContext();
            UserRepository userRepository = new UserRepository(carContext);

            return await userRepository.GetUsersAsync();
        }



        [HttpGet("{id}")]
        public async Task<Users> Users(int id)
        {
            CarContext carContext = new CarContext();
            UserRepository userRepository = new UserRepository(carContext);

            return await userRepository.GetUserByIdAsync(id);
        }
        [HttpPost]
        public void InsertReservation(CarReservation carReservation)
        {


            CarContext carContext = new CarContext();
            CarReservationRepository carReservationRepository = new CarReservationRepository(carContext);
            carReservationRepository.AddReservation(carReservation);

        }

        [HttpPut]
        public async Task<IActionResult> Insert(ReservationIn reservationIn)
        {
            CarReservationController CarReservationController = new CarReservationController();
            var result = CarReservationController.InsertReservationContent(reservationIn);
            //carReservationRepository.GetAllAsync();

            return Ok(result);
        }
    }
    
}