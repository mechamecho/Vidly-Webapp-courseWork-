using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {


        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}