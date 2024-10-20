using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.Models
{
    public class Approval
    {
        [Key]
        [Required]
        [Display(Name = "Approval ID")]
        public int ApprovalId { get; set; }

        // transaction ID
        [Required]
        [Display(Name = "Transaction ID")]
        public int TransactionId { get; set; }

        [Required]
        [Display(Name = "Approval No")]
        [StringLength(20)]
        public string ApprovalNo { get; set; }

        [Required]
        [Display(Name = "Approval Levels")]
        public int ApprovalLevels { get; set; } = 1;

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public string? Remarks { get; set; }

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


        public Transaction? Transaction { get; set; }

        public ICollection<ApprovalDetail>? ApprovalDetails { get; set; }
    }
}
