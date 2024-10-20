using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be {2} to max {1} charaters long")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Password doesn't match.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
    }
}
