namespace RentVehiclePool.Models
{
    public class Approval
    {
        public int ApprovalId { get; set; }

        // transaction ID
        public int TransactionId { get; set; }

        public string ApprovalNo { get; set; }

        // apvUserID from table User
        public int ApvUserId { get; set; }

        public string Status { get; set; }

        public string Remarks { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
