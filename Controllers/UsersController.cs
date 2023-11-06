
using Azure.Messaging;
using CarRental.Data.Context;
using CarRental.Data.Entity;
using CarRental.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class UsersController : Controller
    {
        private UserRepository UserRepository;
        private UserRoleRepository UserRoleRepository;
        private CarContext CarContext;
        private Tools tools;
        public UsersController()
        {
            CarContext = new();
            UserRepository = new(CarContext);
            UserRoleRepository = new(CarContext);
            tools = new();

        }
        public IActionResult Index()
        {
            var a = UserRepository.GetUsers().Where(x => x.RecordStatus == 1);
            List<Users> Usersl = new List<Users>();
            foreach (var item in a)
            {

                Users users = new Users();
                users.Id = item.Id;
                users.Name = item.Name;
                users.Scondname = item.Scondname;
                users.Lastname = item.Lastname;
                users.Recorddate = item.Recorddate;
                users.LasLoginDate = item.LasLoginDate;
                users.RoleType = item.RoleType;
                users.Birthdate = item.Birthdate;
                users.CitizenShipNumber = item.CitizenShipNumber;
                users.usersRoleTypes = CarContext.UsersRoleTypes.Where(x => x.Id == users.RoleType).ToList();
                Usersl.Add(users);



            }
            //UserRoleRepository.GetUsersRoleType().Where(x => x.Id == a);
            return View(Usersl);
        }
        public IActionResult RoleIndex()
        {
            return View(UserRoleRepository.GetUsersRoleType().Where(x=>x.RecordStatus==1).ToList());
        }
        public IActionResult RoleInsert()
        {
            return View();
        }
        public IActionResult InsertRoleContent(UsersRoleType usersRoleType)
        {


            UserRoleRepository.AddRole(usersRoleType);
            return RedirectToAction("RoleIndex");
        }
        public IActionResult RoleUpdate(int Id)
        {
            UsersRoleType usersrole = new UsersRoleType();
            if (Id != 0)
            {
                var a = CarContext.UsersRoleTypes.FirstOrDefault(x => x.Id == Id);
                usersrole = a;
            }
            return View(usersrole);
        }
        public IActionResult RoleDelete(int Id)
        {
            if (Id != 0)
            {
                var a = CarContext.UsersRoleTypes.FirstOrDefault(x => x.Id == Id);
                a.RecordStatus = 2;
                a.RecordDate = DateTime.Now;
                UserRoleRepository.UpdateRole(a);
                
            }
            return RedirectToAction("RoleIndex");
        }
        public IActionResult RoleUpdateContent(UsersRoleType usersRoleType)
        {
            usersRoleType.RecordStatus = 1;
            UserRoleRepository.UpdateRole(usersRoleType);
            return RedirectToAction("RoleIndex");
        }
        public IActionResult InsertUser()
        {
            Users users = new Users();
            var a = UserRoleRepository.GetUsersRoleType();
            users.usersRoleTypes = a;
            return View(users);
        }

        public IActionResult InsertUserContent(Users users)
        {
            tools.citizenshipnumber = users.CitizenShipNumber;
            if (tools.TCKNCheck() == true)
            {
                UserRepository.AddUser(users);
                return RedirectToAction("Index");
            }
            else

            {
                
                return null;
            }


        }
        public IActionResult UserUpdate(int Id)
        {
            Users users = new Users();
            if (Id!=0)
            {
                var a = CarContext.Users.FirstOrDefault(x => x.Id == Id);

                var b = UserRoleRepository.GetUsersRoleType();
                a.Birthdate = Convert.ToDateTime(a.Birthdate).Date;
                a.usersRoleTypes = b;
                users = a;
            }
            

            return View(users);
        }
        public IActionResult UserDelete(int Id)
        {
            var a = CarContext.Users.FirstOrDefault(x => x.Id == Id);
            a.RecordStatus = 2;
            UserRepository.UpdateUser(a);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateUserContent(Users users)
        {
            users.RecordStatus = 1;
            UserRepository.UpdateUser(users);
            return RedirectToAction("Index");
        }

    }


}

