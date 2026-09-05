using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.Record
{
    public record RecordInactiveAccountRequest(
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