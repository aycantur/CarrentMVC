using CarRental.Data.Context;
using CarRental.Data.Entity;

namespace CarRental.Data.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private CarContext context;

        public UserRoleRepository(CarContext _context)
        {
            context = _context;
        }
        public void AddRole(UsersRoleType usersRoleType)
        {
            usersRoleType.RecordDate = DateTime.Now;
            usersRoleType.RecordStatus = 1;
            context.Add(usersRoleType);
            context.SaveChanges();
        }

        public List<UsersRoleType> GetUsersRoleType()
        {
            return context.UsersRoleTypes.ToList();
        }

        public List<UsersRoleType> GetUsersRoleTypeById(int Id)
        {
            return context.UsersRoleTypes.Where(x => x.Id == Id).ToList();
        }

        public void UpdateRole(UsersRoleType usersRoleType)
        {
            usersRoleType.RecordDate = DateTime.Now;
            context.Update(usersRoleType);
            context.SaveChanges();
        }
        public void DeleteRole(UsersRoleType usersRoleType)
        {
            context.Remove(usersRoleType);
            context.SaveChanges();
        }
    }
}
