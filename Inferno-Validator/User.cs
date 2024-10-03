using System.ComponentModel.DataAnnotations;

namespace Inferno_Validator;

public class User
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}