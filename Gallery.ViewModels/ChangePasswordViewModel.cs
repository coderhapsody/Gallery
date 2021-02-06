using System.ComponentModel.DataAnnotations;

namespace Gallery.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Current Password")]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "Invalid Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
