using Model.Base;
using Model.Enums;
using Persistence.Db;

namespace Model.Interface;

public interface IUserDao
{
    public User GetUser(string? name);
    public void AddUser(User user);
    public List<User> GetAllUsers();
    public void UpdateUser(User user,  string newName);
}