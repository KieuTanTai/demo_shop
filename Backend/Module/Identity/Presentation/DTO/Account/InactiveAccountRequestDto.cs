using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.DTO.Account
{
    public record InactiveAccountRequestDto(
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