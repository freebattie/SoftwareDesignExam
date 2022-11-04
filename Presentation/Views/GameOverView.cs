
using Model.Interface;
using Persistence.Db;
using Presentation.Utils;

namespace Presentation.Views;

public class GameOverView : IView

{
    private readonly User user;

    public GameOverView(User user)
    {
        this.user = user;
    }
    
    private string asciGraphic = @"
  /$$$$$$   /$$$$$$  /$$      /$$ /$$$$$$$$        /$$$$$$  /$$    /$$ /$$$$$$$$ /$$$$$$$ 
 /$$__  $$ /$$__  $$| $$$    /$$$| $$_____/       /$$__  $$| $$   | $$| $$_____/| $$__  $$
| $$  \__/| $$  \ $$| $$$$  /$$$$| $$            | $$  \ $$| $$   | $$| $$      | $$  \ $$
| $$ /$$$$| $$$$$$$$| $$ $$/$$ $$| $$$$$         | $$  | $$|  $$ / $$/| $$$$$   | $$$$$$$/
| $$|_  $$| $$__  $$| $$  $$$| $$| $$__/         | $$  | $$ \  $$ $$/ | $$__/   | $$__  $$
| $$  \ $$| $$  | $$| $$\  $ | $$| $$            | $$  | $$  \  $$$/  | $$      | $$  \ $$
|  $$$$$$/| $$  | $$| $$ \/  | $$| $$$$$$$$      |  $$$$$$/   \  $/   | $$$$$$$$| $$  | $$
 \______/ |__/  |__/|__/     |__/|________/       \______/     \_/    |________/|__/  |__/                                                                                                                                                                   
";
    public void GameOverMenu() {
        Writer.PrintLine(asciGraphic);
        Writer.PrintLine("----------------------------");
        Writer.PrintLine("----------GAME RESULT-------");
        Writer.PrintLine($"PLAYER LEVEL  {user.Level} ");
        Writer.PrintLine("----------------------------");
        Writer.PrintLine("PRESS 1 TO RESTART          ");
        Writer.PrintLine("----------------------------");
        Writer.PrintLine("PRESS 2 TO QUIT             ");
        Writer.PrintLine("----------------------------");
    }
    public void Draw() {
        GameOverMenu();
    }
}