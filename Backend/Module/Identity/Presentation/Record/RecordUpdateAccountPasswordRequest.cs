using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.Record
{
    public record RecordUpdateAccountPasswordRequest(
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