using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.Record.Account
{
    public record UpdateAccountPasswordRequestRecord(
        [Required]
        [EmailAddress]
        string Email,
        [Required]
        [DataType(DataType.Password)]
        string NewPassword,
        [Required]
        [DataType(DataType.Password)]
        string OldPassword
    );
}