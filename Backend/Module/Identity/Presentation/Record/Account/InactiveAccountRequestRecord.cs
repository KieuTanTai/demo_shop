using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.Record.Account
{
    public record InactiveAccountRequestRecord(
        [Required]
        [EmailAddress]
        string Email,
        [Required]
        [DataType(DataType.Password)]
        string Password,
        [Required]
        [DataType(DataType.Password)]
        string ConfirmPassword
    );
}