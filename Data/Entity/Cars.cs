namespace CarRental.Data.Entity
{
    public class Cars
    {
        public int Id{ get; set; }
        public string? Name { get; set; }
        public int CarType{ get; set; }
        public int EngineType{ get; set; }
        public string EngineVolume { get; set; }
        public decimal Price{ get; set; }
        public DateTime RecordDate{ get; set; }
        public int RecordStatus{ get; set; }



    }
}
