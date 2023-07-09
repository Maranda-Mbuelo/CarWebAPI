namespace CarWebAPI.Models.DTO
{
    public class AddCarRequest
    {
        public string CarName { get; set; }

        public string CarModel { get; set; }

        public string CarType { get; set; }

        public string YearName { get; set; }

        public string CarYearMake { get; set; }

        public string CarTransmission { get; set; }

        public string CarEngineType { get; set; }

        public int CarNoOfGears { get; set; }

        public int CarHorsePower { get; set; }

        public int CarTorque { get; set; }

        public int CarKilowatts { get; set; }

        public int CarEngineSize { get; set; }

        public int CarNoOfSeats { get; set; }

        public int CarFuelConsuption { get; set; }

        public int CarFuelTankSize { get; set; }

        public int CarAcceleration { get; set; }

        public int CarPrice { get; set; }

        public string CarFeaturedImageUrl { get; set; }
        //
        public IFormFile CarImage { get; set; }
        //

        public string UrlHandle { get; set; }

        public string Author { get; set; }
    }
}
