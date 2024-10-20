using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.Models
{
    public class Roles
    {
        [Key]
        [Display(Name = "Role ID")]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        [StringLength(50)]
        public string RoleName { get; set; }

        public string? Description { get; set; }

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


        //public ICollection<User> Users { get; set; }
    }
}
