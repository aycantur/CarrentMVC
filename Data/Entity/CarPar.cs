using System.Security.Principal;

namespace CarRental.Data.Entity
{
    public class CarPar
    {
        public int Id{ get; set; }
        public int Type{ get; set; }
        public string Name{ get; set; }
        public DateTime RecordDate{ get; set; }
        public int RecordStatus{ get; set; }

    }
}
