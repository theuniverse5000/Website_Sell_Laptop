using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class RoleServices : IRoleServices
    {
        ApplicationDbContext _dbContext;
        public RoleServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CreateRole(Role a)
        {
            try
            {
                _dbContext.Roles.Add(a);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                var a = _dbContext.Roles.Find(id);
                _dbContext.Roles.Remove(a);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Role> GetAllRoles()
        {
            return _dbContext.Roles.ToList();
        }
        public bool IsNameRoleExist(string Name)
        {
            var linh = _dbContext.Roles;
            var a = linh.FirstOrDefault(a => a.RoleName == Name);
            if (a != null) return true;
            else return false;
        }

        public bool UpdateRole(Role a)
        {
            try
            {
                var linh = _dbContext.Roles.Find(a.Id);
                linh.RoleName = a.RoleName;
                linh.Description = a.Description;
                linh.Status = a.Status;
                _dbContext.Roles.Update(linh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
