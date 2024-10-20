using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User Login")]
        [StringLength(10)]
        public string UserLogin { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        // roleID
        [Required]
        [Display(Name = "Role ID")]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; } = false;

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


        public Role? Role { get; set; }

        //public ICollection<ApprovalDetail> ApprovalDetails { get; set; }
    }
}
