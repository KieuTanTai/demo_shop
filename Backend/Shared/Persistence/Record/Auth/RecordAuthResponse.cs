using Shared.Enum;

namespace Shared.Persistence.Record.Auth
{
    public record RecordAuthResponse(
        string Email,
        bool IsActive,
        List<string> RoleNames,
        string? FirstName,
        string? LastName,
        string? AvatarUrl,
        string? PhoneNumber,
        DateOnly? DateOfBirth,
        ESystemUserGender Gender, 
        DateTime CreatedAt, 
        DateTime UpdatedAt
    );
}