using System;
using System.ComponentModel.DataAnnotations;

namespace Tedu.Shop.Models;

public class ExternalLoginListViewModel
{
    public string ReturnUrl { get; set; }
}
public class ExternalLoginConfirmationViewModel
{
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
}