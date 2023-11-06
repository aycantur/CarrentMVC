using CarRental.Data.Context;
using CarRental.Data.Entity;
using CarRental.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class CarParController : Controller
    {
        private CarParRepository CarParRepository;
        private CarContext CarContext;
        public CarParController()
        {
            CarContext = new();
            CarParRepository = new(CarContext);
        }
        public IActionResult Index()
        {
            var a = CarParRepository.GetCarPars();
            
            List<CarParUnion> carParUnions = new List<CarParUnion>();
            
            foreach (var item in a)
            {
                CarParUnion carParUnion = new CarParUnion();
                carParUnion.Id = item.Id;
                carParUnion.Name = item.Name;
                carParUnion.Type = item.Type;
                carParUnion.TypeName = item.Type == 1 ? "Araç Türü" : "Motor Türü";
                carParUnions.Add(carParUnion);
            }
            return View(carParUnions);
        }
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult InsertContent(CarPar carPar)
        {
            try
            {
                carPar.RecordDate = DateTime.Now;
                carPar.RecordStatus = 1;
                CarParRepository.AddCarPar(carPar);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IActionResult Delete(int Id)
        {
            CarParRepository.DeleteCarPar(Id);
            return RedirectToAction("Index");
        }

       
        public IActionResult Update(int Id)
        {
            CarPar carPar = new CarPar();
            if (Id != 0)
            {
                var a = CarContext.CarPar.FirstOrDefault(x => x.Id == Id);
                carPar = a;
            }
            return View(carPar);

        }
        [HttpPost]
        public IActionResult UpdateContent(CarPar carPar)
        {
            carPar.RecordDate = DateTime.Now;
            carPar.RecordStatus = 2;
            CarParRepository.UpdateCarPar(carPar);
            return RedirectToAction("Index");

        }

        public IActionResult CarParContent()
        {

            return View();
        }
    }
}
