using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.Models
{
    public class User : IdentityUser
    {
        [Display(Name = "User ID")]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(50)]
        public string FullName { get; set; }

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


        public Roles? Role { get; set; }

        //public ICollection<ApprovalDetail> ApprovalDetails { get; set; }
    }
}
