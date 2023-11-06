using CarRental.Data.Context;
using CarRental.Data.Entity;
using CarRental.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class HomeController:Controller
    {
        private CarContext carContext;
        private CarParRepository CarParRepository;
        
        public HomeController()
        {
            carContext = new();
            CarParRepository = new(carContext);
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
