using CarRental.Data.Context;
using CarRental.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repository
{
    public class CarParRepository : ICarParRepository
    {
        private CarContext context;

        public CarParRepository(CarContext _context)
        {
            context = _context;
        }
        public void AddCarPar(CarPar carPar)
        {

            if (carPar.Name is null)
            {
                Console.WriteLine("Ad Girilmeli");
            }
            else
            {
                context.CarPar.Add(carPar);
                context.SaveChanges();
            }
        }

        public void DeleteCarPar(int Id)
        {
            var a = context.CarPar.FirstOrDefault(x => x.Id == Id);
            context.CarPar.Remove(a);
            context.SaveChanges();
        }

        public List<CarPar> GetCarParById(int Id)
        {
            return context.CarPar.Where(x => x.Id == Id).ToList();
        }

        public List<CarPar> GetCarParByType(int Id)
        {
            return context.CarPar.Where(x => x.Type == Id).ToList();
        }

        public List<CarPar> GetCarPars()
        {
            return context.CarPar.ToList();
        }

        public async Task<List<CarPar>> GetCarParsAsync()
        {
            return await context.CarPar.ToListAsync();
        }



        public void UpdateCarPar(CarPar carPar)
        {
            context.Update(carPar);
            context.SaveChanges();
        }
    }
}
