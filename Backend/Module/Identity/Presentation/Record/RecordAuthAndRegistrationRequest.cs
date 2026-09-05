using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.Record
{
    public record RecordAuthAndRegistrationRequest(
        [Required]
        [EmailAddress]
        string Email,
        [Required]
        [DataType(DataType.Password)]
        string Password
    );
}