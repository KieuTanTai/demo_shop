using System.ComponentModel.DataAnnotations;

namespace Identity.Presentation.DTO.Account
{
    public record RegisterOrLoginRequest(
        [Required]
        [EmailAddress]
        string Email,
        [Required]
        string Password
    );
}