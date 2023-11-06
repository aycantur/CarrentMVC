using CarRental.Data.Entity;

namespace CarRental.Data.Repository
{
    public interface ICarsRepository
    {
        void AddCar(Cars cars);
        void UpdateCar(Cars cars);
        void DeleteCar(int Id);
        public Task<List<Cars>> GetAllAsync();
        List<Cars> GetCarById(int Id);
        List<Cars> GetCars();
        List<Cars> GetAllCars();
    }
}
