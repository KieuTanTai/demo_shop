namespace Identity.Models.Account
{
    public class AccountAdditionalPermissionModel
    {
        public Guid AccountId { get; init; }

        public Guid PermissionId { get; init; }

        public DateTime AssignedAt { get; init; } = DateTime.UtcNow;
        
        public AccountAdditionalPermissionModel() {}
        
        public AccountAdditionalPermissionModel(Guid accountId, Guid permissionId)
        {
            AccountId = accountId;
            PermissionId = permissionId;
        }
    }
}