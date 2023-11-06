using CarRental.Data.Entity;

namespace CarRental.Data.Repository
{
    public interface IUserRoleRepository
    {
        void AddRole(UsersRoleType usersRoleType);
        void UpdateRole (UsersRoleType usersRoleType);
        void DeleteRole(UsersRoleType usersRoleType);

        List<UsersRoleType> GetUsersRoleTypeById(int Id);
        List<UsersRoleType> GetUsersRoleType();

    }
}
