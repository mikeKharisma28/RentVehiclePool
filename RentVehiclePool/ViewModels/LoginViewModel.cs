using System.ComponentModel.DataAnnotations;

namespace RentVehiclePool.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
