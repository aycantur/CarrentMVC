using CarRental.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Data.Context
{
    public class CarContext:DbContext
    {
        public DbSet<CarPar> CarPar { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<CarReservation> CarReservation{ get; set; }
        public DbSet<Users> Users{ get; set; }
        public DbSet<UsersRoleType> UsersRoleTypes { get; set; }
        public List<CarsList> CarsLists{ get; set; }
        public List<CarParUnion> carParUnions { get; set; }
        public List<ReservationFullData> reservationFullDatas { get; set; }
        public List<ReservationIn> reservationIns{ get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("server=s0134DBTEMP;database=CarRentalAYC; integrated security=true; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
