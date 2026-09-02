using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.DTO.Account
{
    public record AuthAndRegistrationRequestDto(
        [Required]
        [EmailAddress]
        string Email,
        
        [Required]
        [DataType(DataType.Password)]
        string Password
    );
}