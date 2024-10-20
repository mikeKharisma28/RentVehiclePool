using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.Models
{
    public class Transaction
    {
        [Key]
        [Display(Name = "Transaction ID")]
        public int TransactionId { get; set; }

        // vehicleID
        [Required]
        [Display(Name = "Vehicle ID")]
        public int VehicleId { get; set; }

        [Required]
        [Display(Name = "Transaction No")]
        [StringLength(20)]
        public string TransactionNo { get; set; }

        [Required]
        [Display(Name = "Transaction Type")]
        [StringLength(10)]
        public string TransactionType { get; set; }

        public string? Description { get; set; }

        [Required]
        [Display(Name = "Driver Name")]
        [StringLength(50)]
        public string DriverName { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Date Used")]
        public DateTime UsedDate { get; set; }

        [Required]
        [Display(Name = "Date Returned")]
        public DateTime ReturnedDate { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Display(Name = "Created By")]
        [StringLength(20)]
        public string CreatedBy { get; set; }

        [Required]
        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [Display(Name = "Updated By")]
        [StringLength(20)]
        public string UpdatedBy { get; set; }


        public Vehicle? Vehicle { get; set; }

        public Approval? Approval { get; set; }
    }
}
