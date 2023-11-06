using CarRental.Data.Entity;

namespace CarRental.Data.Repository
{
    public interface IUserRepository
    {
        void AddUser (Users users);
        void UpdateUser (Users users); 
        
        List<Users> GetUserById(int Id);

        List<Users> GetUserByCitizenshipNumber (string Id);
        List<Users> GetUsers();
        public List<Users> GetUsersAll();
        Task<List<Users>> GetUsersAsync();
        Task<Users> GetUserByIdAsync(int id);
    }
}
