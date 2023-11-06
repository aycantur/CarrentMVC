using CarRental.Data.Context;
using CarRental.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private CarContext Context;
        private object a;

        public UserRepository(CarContext Context)
        {
            this.Context = Context;
        }

        
        public void AddUser(Users users)
        {
            users.Recorddate = DateTime.Now;
            users.RecordStatus = 1;
            Context.Add(users);
            Context.SaveChanges();
        }

        public List<Users> GetUserByCitizenshipNumber(string citizenshipnumber)
        {
           return Context.Users.Where(x => x.CitizenShipNumber == citizenshipnumber).ToList();
        }

        public List<Users> GetUserById(int Id)
        {
            return Context.Users.Where(x => x.Id == Id).ToList();
        }

        public Task<Users> GetUserByIdAsync(int id)
        {
            return Context.Users.Where(x => x.RecordStatus == 1 &&x.Id==id).FirstOrDefaultAsync();
        }

        public List<Users> GetUsers()
        {
            return Context.Users.Where(x=>x.RecordStatus==1).ToList();
        }

        public List<Users> GetUsersAll()
        {
            return Context.Users.ToList();
        }

        public async Task<List<Users>> GetUsersAsync()
        {
            return await Context.Users.ToListAsync(); ;
        }

        public void UpdateUser(Users users)
        {
            {
                users.Recorddate = DateTime.Now;
                Context.Update(users);
                Context.SaveChanges();
            }
        }
    }
}
