using Identity.Infrastructure.Persistence.DBContext;
using Identity.Interfaces.IRepository;
using Identity.Models.Role;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repository.Role
{
    public class RolePermissionRepository(IdentityDbContext context) : IBaseAssociativeRepository<RolePermissionModel, Guid>
    {
        private readonly IdentityDbContext _db = context;

        #region POST

        public async Task<int> AddAsync(List<RolePermissionModel> entities, CancellationToken cancellationToken = default)
        {
            if (entities is null || entities.Count == 0)
            {
                throw new ArgumentException("Entities is required.", nameof(entities));
            }
            // var filteredRolePermissions = await GetNotExistedEntitiesList(entities, cancellationToken);
            // if (!filteredRolePermissions.Any())
            //     throw new InvalidOperationException("All role permissions already exist!");
            // await _db.RolePermissions.AddRangeAsync(filteredRolePermissions, cancellationToken);

            await _db.RolePermissions.AddRangeAsync(entities, cancellationToken);
            return await _db.SaveChangesAsync(cancellationToken);
        }

        #endregion

        // private check if role and permission are existed
        // private async Task<List<RolePermissionModel>> GetNotExistedEntitiesList(List<RolePermissionModel> entities,
        //     CancellationToken cancellationToken = default)
        // {
        //     var existedRolePermissions = await GetAllAsync(cancellationToken);
        //     return entities.Where(entity => !existedRolePermissions.Any(existedRolePermission =>
        //             existedRolePermission.RoleId == entity.RoleId && existedRolePermission.PermissionId == entity.PermissionId))
        //         .ToList();
        // }

        #region DELETE

        public async Task<int> DeleteAsync(Guid firstForeignId, Guid secondForeignId,
            CancellationToken cancellationToken = default)
        {
            if (firstForeignId == Guid.Empty || secondForeignId == Guid.Empty)
            {
                throw new ArgumentException("First foreign id and second foreign id is required.", nameof(firstForeignId));
            }
            var existedRolePermission = await GetByIdAsync(firstForeignId, secondForeignId, cancellationToken);
            if (existedRolePermission is null)
            {
                return 0;
            }
            _db.RolePermissions.Remove(existedRolePermission);
            return await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteByFirstForeignIdAsync(Guid firstForeignId, CancellationToken cancellationToken = default)
        {
            if (firstForeignId == Guid.Empty)
            {
                throw new ArgumentException("First foreign id is required.", nameof(firstForeignId));
            }
            var rolePermissionsToDelete = await _db.RolePermissions.Where(rp => rp.RoleId == firstForeignId).ToListAsync(cancellationToken);
            _db.RolePermissions.RemoveRange(rolePermissionsToDelete);
            return await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteBySecondForeignIdAsync(Guid secondForeignId, CancellationToken cancellationToken = default)
        {
            if (secondForeignId == Guid.Empty)
            {
                throw new ArgumentException("Second foreign id is required.", nameof(secondForeignId));
            }
            var rolePermissionsToDelete = await _db.RolePermissions.Where(rp => rp.PermissionId == secondForeignId).ToListAsync(cancellationToken);
            _db.RolePermissions.RemoveRange(rolePermissionsToDelete);
            return await _db.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region GET

        public async Task<IReadOnlyList<RolePermissionModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _db.RolePermissions.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<RolePermissionModel?> GetByIdAsync(Guid firstForeignId, Guid secondForeignId,
            CancellationToken cancellationToken = default)
        {
            return await _db.RolePermissions.AsNoTracking().FirstOrDefaultAsync(
                rolePermission =>
                    rolePermission.RoleId == firstForeignId && rolePermission.PermissionId == secondForeignId,
                cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid firstForeignId, Guid secondForeignId,
            CancellationToken cancellationToken = default)
        {
            return await _db.RolePermissions.AnyAsync(
                rolePermission =>
                    rolePermission.RoleId == firstForeignId && rolePermission.PermissionId == secondForeignId,
                cancellationToken);
        }

        #endregion
    }
}