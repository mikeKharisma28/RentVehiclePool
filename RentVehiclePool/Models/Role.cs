using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
