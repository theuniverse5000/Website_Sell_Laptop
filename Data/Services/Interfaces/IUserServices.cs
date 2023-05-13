using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IUserServices
    {
        bool CreateUser(User thao);
        bool UpdateUser(User thao);
        bool DeleteUser(Guid id);
        bool IsUsernameExist(string username);
        List<User> GetAllUsers();
        User GetUserById(Guid id);
        List<User> GetUserByName(string username);
        bool IsUsernameAndPassword(string username, string password);
        bool IsAdministrator(string username, string password);
        //  UserView GetUserWithUsernameAndPassWord(string username, string password);

    }
}
