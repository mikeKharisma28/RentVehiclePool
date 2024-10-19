using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.Models
{
    public class Vehicle
    {
        [Key]
        [Display(Name = "Vehicle ID")]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(20)]
        public string Brand { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "License Plate")]
        [StringLength(10)]
        public string LicensePlate { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Is Used?")]
        public bool IsUsed { get; set; } = false;

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


        public ICollection<Transaction> Transactions { get; set; }
    }
}
