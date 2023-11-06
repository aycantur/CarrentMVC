using CarRental.Data.Entity;

namespace CarRental.Data.Repository
{
    public interface ICarParRepository
    {
        void AddCarPar(CarPar carPar);
        void UpdateCarPar(CarPar carPar);
        void DeleteCarPar(int Id);

        List<CarPar> GetCarParById(int Id);

        List<CarPar> GetCarParByType(int Id);
        List<CarPar> GetCarPars();
        Task<List<CarPar>> GetCarParsAsync();


    }
}
