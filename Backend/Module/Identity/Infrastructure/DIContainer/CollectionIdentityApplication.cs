using Identity.Infrastructure.Persistence.DBContext;
using Identity.Infrastructure.Repository;
using Identity.Infrastructure.Repository.Account;
using Identity.Infrastructure.Repository.Permission;
using Identity.Infrastructure.Repository.Role;
using Identity.Interfaces.IRepository;
using Identity.Models.Account;
using Identity.Models.Permission;
using Identity.Models.Role;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;

namespace Identity.Infrastructure.DIContainer
{
    public static class CollectionIdentityApplication
    {
        public static IServiceCollection AddIdentityApplicationCollection(this IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}