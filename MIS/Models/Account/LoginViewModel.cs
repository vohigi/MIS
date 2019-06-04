using System.ComponentModel.DataAnnotations;

namespace MIS.ViewModels
{
  public class LoginViewModel
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
  }
}