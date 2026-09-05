using Shared.Enum;

namespace Identity.Presentation.Record
{
    public record RecordAuthAndRegistrationResponse(
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