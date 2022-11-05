using Model.Base;
using Model.Base.Player;


namespace Model.Interface;

public interface IUserDAO
{
    public User GetUser(string? name);
    public void AddUser(User user);
    public List<User> GetAllUsers();
}