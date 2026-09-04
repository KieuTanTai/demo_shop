using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.Record.Account
{
    public record AuthAndRegistrationRequestRecord(
        [Required]
        [EmailAddress]
        string Email,
        [Required]
        [DataType(DataType.Password)]
        string Password
    );
}