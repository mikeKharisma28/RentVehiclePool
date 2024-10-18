namespace RentVehiclePool.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public int Year { get; set; }

        public bool IsUsed { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate{ get; set; }

        public string UpdatedBy { get; set; }

    }
}
