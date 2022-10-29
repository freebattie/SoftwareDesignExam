using Persistence.Db;

namespace SoftwareDesignExam;

public class UserMenu
{
    private User _user = new();
    private UserDAO _userDao = new();
    private Program _program = new();
    
    public void StartMenu()
    {
        Console.WriteLine("\nWelcome to Rouge Dungeon!");
        Console.WriteLine("\nHave an existing account? Enter press 's' to start playing and view your high score! If not press 'r' to make a new one");
        Console.WriteLine("\nPress 'q' to quit");
        
        char userChoice = new ();
        while (userChoice != 'q')
        {
            userChoice = Console.ReadKey().KeyChar;
            switch (userChoice)
            {
                case 'r': 
                    Console.WriteLine("\nChoose a user name (user name may already be taken, so choose wisely: )");
                    _user.Name = Console.ReadLine();
                    _user.Level = 10;
                    _user.Topscore = 0;
                    
                    _userDao.AddUser(_user);
                    _program.StartGame(_user);
                    break;
                case 's':
                    Console.WriteLine("\nPlease enter your user name");
                    var userInput = Console.ReadLine();
                    _user = _userDao.GetUser(userInput);
                    _program.StartGame(_user);
                    break;
            }
        }
    }
}