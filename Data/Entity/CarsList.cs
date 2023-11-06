namespace CarRental.Data.Entity
{
    public class CarsList:Cars
 
    {
       
        public string CarTypeName{ get; set; }
        public string EngineTypeName{ get; set; }
        public List<CarPar> carParsType { get; set; }
        public List<CarPar> carParsEngineType { get; set; }
    }
}
