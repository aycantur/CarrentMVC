namespace CarRental.Data.Entity
{
    public class Users
    {
        public int Id{ get; set; }
        public string CitizenShipNumber{ get; set; }
        public DateTime Birthdate{ get; set; }
        public string Name{ get; set; }
        public string? Scondname { get; set; }
        public string Lastname{ get; set; }
        public int RoleType{ get; set; }
        public int RecordStatus{ get; set; }
        public DateTime Recorddate{ get; set; }
        public DateTime LasLoginDate{ get; set; }
        public string Password{ get; set; }

        public List<UsersRoleType>? usersRoleTypes { get; set; }
    }
}
