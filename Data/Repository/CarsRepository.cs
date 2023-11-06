using CarRental.Data.Context;
using CarRental.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repository
{
    public class CarsRepository : ICarsRepository
    {
        private CarContext context;

        public CarsRepository(CarContext _context)
        {
            context = _context;
        }
        public void AddCar(Cars cars)
        {
            context.Cars.Add(cars);
            context.SaveChanges();
        }

        public void DeleteCar(int Id)
        {
            var a=context.Cars.FirstOrDefault(x => x.Id == Id);
            a.RecordStatus = 2;
            a.RecordDate = DateTime.Now;
            context.Cars.Update(a);
            context.SaveChanges();
        }

        public async Task<List<Cars>> GetAllAsync()
        {
            return  await  context.Cars.ToListAsync();
        }


        public List<Cars> GetCarById(int Id)
        {
            return context.Cars.Where(x=>x.Id==Id).ToList();
        }

        public List<Cars> GetCars()
        {
            return context.Cars.Where(x=>x.RecordStatus==1).ToList();
        }
        public List<Cars> GetAllCars()
        {
            return context.Cars.ToList();
        }
        public void UpdateCar(Cars cars)
        {
            context.Cars.Update(cars);
            context.SaveChanges();
        }
    }
}
