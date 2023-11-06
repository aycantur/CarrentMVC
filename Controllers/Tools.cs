using CarRental.Data.Context;
using CarRental.Data.Entity;
using CarRental.Data.Repository;

namespace CarRental.Controllers
{
    public class Tools
    {
        public string citizenshipnumber { get; set; }
        private UserRoleRepository UserRoleRepository;
        private CarReservationRepository CarReservationRepository;
        private CarContext CarContext;
        public bool TCKNCheck()
        {


            if (citizenshipnumber.Length == 11)
            {
                int[] e = new int[11];
                int i = 0;

                foreach (var f in citizenshipnumber)
                {
                    string g = Convert.ToString(f);
                    e[i] = int.Parse(g);
                    i++;

                }

                if (((e[0] + e[2] + e[4] + e[6] + e[8]) * 7 - (e[1] + e[3] + e[5] + e[7])) % 10 == e[9])
                {
                    int a = 0;
                    for (int k = 0; k < 10; k++)
                    {
                        a = e[k] + a;
                    }
                    if (a % 10 == e[10])
                    {
                        CarContext = new();
                        UserRoleRepository = new(CarContext);
                        var ab = CarContext.Users.Where(x => x.CitizenShipNumber == citizenshipnumber).ToList().FirstOrDefault();

                        if (ab is null)
                        {

                            return true;
                        }
                        else
                        {
                            return false;

                        }

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool CarSuitable(ReservationIn reservationIn)
        {
            CarContext = new();
            CarReservationRepository = new(CarContext);
            var a = CarReservationRepository.GetCarReservations().Where(x => x.CarId==reservationIn.CarId &&x.Id!=reservationIn.Id).ToList();
            
            foreach (var item in a)
            {
                if (((item.ReservationEndDate >= reservationIn.ReservationStartDate) && (reservationIn.ReservationStartDate >= item.ReservationStartDate)) ||
                    ((item.ReservationEndDate >= reservationIn.ReservationEndDate) && (reservationIn.ReservationEndDate >= item.ReservationStartDate)) ||
                    ((reservationIn.ReservationStartDate <= item.ReservationStartDate) && (reservationIn.ReservationEndDate >= item.ReservationEndDate)))
                {
                    return true;
                }
                
            }

            return false;
        }

    }
}

