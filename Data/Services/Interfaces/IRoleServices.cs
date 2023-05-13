using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IRoleServices
    {
        bool CreateRole(Role a);
        bool UpdateRole(Role a);
        bool DeleteRole(Guid id);
        bool IsNameRoleExist(string Name);
        List<Role> GetAllRoles();
    }
}
