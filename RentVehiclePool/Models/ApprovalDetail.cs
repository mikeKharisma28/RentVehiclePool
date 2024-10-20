using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.Models
{
    public class ApprovalDetail
    {
        [Key]
        [Display(Name = "Approval Detail ID")]
        public int ApprovalDetailId { get; set; }

        [Required]
        [Display(Name = "Approval ID")]
        public int ApprovalId { get; set; }

        [Required]
        [Display(Name = "Approval User ID")]
        public Guid ApvUserId { get; set; }

        [Required]
        public int Level { get; set; }

        [Display(Name = "Is Approved?")]
        public bool? IsApproved { get; set; }

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


        public Approval Approval { get; set; }

        //public User ApvUser { get; set; }
    }
}
