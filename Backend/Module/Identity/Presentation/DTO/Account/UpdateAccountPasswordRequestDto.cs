using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.DTO.Account
{
    public record UpdateAccountPasswordRequestDto(
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