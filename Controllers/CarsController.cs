using Azure.Messaging;
using CarRental.Data.Context;
using CarRental.Data.Entity;
using CarRental.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        private CarsRepository CarsRepository;
        private CarParRepository CarParRepository;
        private CarContext CarContext;
        public CarsController()
        {
            CarContext = new();
            CarsRepository = new(CarContext);
            CarParRepository = new(CarContext);
            
        }
        public IActionResult Index()
        {
            var a = CarsRepository.GetCars();
            
            List<CarsList> carsLists = new List<CarsList>();
            
            
            foreach (var item in a)
            {
                CarsList carsList = new CarsList();
                var b = CarParRepository.GetCarParById(item.CarType).Where(x=>x.Type==1).Select(x => x.Name);
                var c = CarParRepository.GetCarParById(item.EngineType).Where(x => x.Type == 2).Select(x=>x.Name);
                carsList.Id = item.Id;
                carsList.Name = item.Name;
                carsList.EngineVolume = item.EngineVolume;
                carsList.CarType = item.CarType;
                carsList.CarTypeName = b.First();
                carsList.EngineTypeName = c.First();
                carsList.RecordDate = item.RecordDate;
                carsList.RecordStatus = item.RecordStatus;
                carsList.EngineType = item.EngineType;
                carsList.Price = item.Price;
                carsLists.Add(carsList);
                
            }
            
            return View(carsLists);
        }
        public IActionResult Insert()
        {
            CarsList carsList = new CarsList();
            var cartype=CarParRepository.GetCarParByType(1);
            var enginetype = CarParRepository.GetCarParByType(2);
            carsList.carParsType = cartype;
            carsList.carParsEngineType = enginetype;
            return View(carsList);
        }

        public IActionResult InsertContent(Cars cars)
        {
            cars.CarType.ToString();
            cars.RecordDate = DateTime.Now;
            cars.RecordStatus = 1;
            CarsRepository.AddCar(cars);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)

        {
            CarsList carsList = new CarsList();
            var b = CarParRepository.GetCarPars();
            var a = CarContext.Cars.FirstOrDefault(x => x.Id == Id);
            if (Id != 0)
            {
                
                carsList.Id = a.Id;
                carsList.Name = a.Name;
                carsList.CarType = a.CarType;
                carsList.EngineType = a.EngineType;
                carsList.EngineVolume = a.EngineVolume;
                carsList.Price = a.Price;
                carsList.RecordDate = DateTime.Now;
                carsList.carParsEngineType = b.Where(x=>x.Type==2).ToList();
                carsList.carParsType = b.Where(x => x.Type == 1).ToList();
            }
            return View(carsList);
            
            
        }

        public IActionResult UpdateContent(Cars cars)
        {
            cars.RecordDate = DateTime.Now;
            cars.RecordStatus = 1;
            CarsRepository.UpdateCar(cars);
            return RedirectToAction("Index");
        }
        public IActionResult Delete (int Id)
        {
            Cars cars = new Cars();
            cars=CarsRepository.GetCarById(Id).FirstOrDefault();
            cars.RecordStatus = 2;
            cars.RecordDate = DateTime.Now;
            CarsRepository.UpdateCar(cars);    
            return RedirectToAction("Index");
        }
    }
}
