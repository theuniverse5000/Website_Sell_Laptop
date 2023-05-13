using Data.Models;
using Data.Services.Interfaces;
using Data.Models.ViewModels;

namespace Data.Services.Implements
{
    public class UserServices : IUserServices
    {
        ApplicationDbContext _dbContext;
        public UserServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CreateUser(User thao)
        {
            try
            {
                _dbContext.Users.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var thao = _dbContext.Users.Find(id);
                _dbContext.Users.Remove(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(a => a.Id == id);
        }

        public List<User> GetUserByName(string username)
        {
            return _dbContext.Users.Where(a => a.Username == username).ToList();
        }

        public bool IsUsernameAndPassword(string username, string password)
        {
            var thao = GetAllUsers().FirstOrDefault(a => a.Username == username && a.Password == password && a.Status == 1);
            if (thao != null) return true;
            return false;
        }
        public bool IsAdministrator(string username, string password)
        {
            List<UserView> thao = new List<UserView>();
            thao = (from a in _dbContext.Users.ToList()
                    join b in _dbContext.Roles.ToList() on a.IdRole equals b.Id
                    select new UserView
                    {
                        Id = a.Id,
                        Username = a.Username,
                        Password = a.Password,
                        Status = a.Status,
                        RoleName = b.RoleName
                    }
                ).ToList();

            var linh = thao.FirstOrDefault(a => a.Username == username && a.Password == password && a.Status == 1 && a.RoleName == "Administrators");
            if (linh != null) return true;
            return false;
        }

        public bool IsUsernameExist(string username)
        {
            var linh = _dbContext.Users;
            var thao = linh.FirstOrDefault(a => a.Username == username);
            if (thao != null) return true;
            else return false;
        }
        //public UserWithUsernameAndPassWord(string username, string password)
        // {
        //       List<UserView> thao = new List<UserView>();
        //     thao = (from a in _dbContext.Users.ToList()
        //             join b in _dbContext.Roles.ToList() on a.IdRole equals b.Id
        //             select new UserView
        //             {
        //                 Id = a.Id,
        //                 Username = a.Username,
        //                 Password = a.Password,
        //                 Status = a.Status,
        //                 RoleName = b.RoleName
        //             }
        //         ).ToList();
        //    var linh= thao.Where(x => x.Username == username && x.Password == password && x.RoleName == "Administrators");
        //     return linh;
        // }

        public bool UpdateUser(User thao)
        {
            try
            {
                var linh = _dbContext.Users.Find(thao.Id);
                linh.Password = thao.Password;
                linh.Status = thao.Status;
                _dbContext.Users.Update(linh);
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
