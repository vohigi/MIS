using System.ComponentModel.DataAnnotations;

namespace MIS.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    [Required]
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
  }
}