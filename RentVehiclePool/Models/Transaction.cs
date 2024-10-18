namespace RentVehiclePool.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        // vehicleID

        public string TransactionNo { get; set; }

        public string TransactionType { get; set; }

        public string Description { get; set; }

        public string DriverName { get; set; }

        public DateTime UsedDate { get; set; }

        public DateTime ReturnedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
