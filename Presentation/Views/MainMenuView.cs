
using Model.Interface;
using Persistence.Db;
using Presentation.Utils;

namespace Presentation.Views;

public class MainMenuView : IView
{

    private string asciString = @"
  _____   ____  _    _  _____ ______      _____          _   _  _____ ______ _____  
 |  __ \ / __ \| |  | |/ ____|  ____|    |  __ \   /\   | \ | |/ ____|  ____|  __ \ 
 | |__) | |  | | |  | | |  __| |__        | |  | | /  \  |  \| | |  __| |__  | |__)|
 |  _  /| |  | | |  | | | |_ |  __|      | |  | |/ /\ \ | . ` | | |_ |  __| |  _  / 
 | | \ \| |__| | |__| | |__| | |____     | |__| / ____ \| |\  | |__| | |____| | \ \ 
 |_|  \_\\____/ \____/ \_____|______|    |_____/_/    \_\_| \_|\_____|______|_|  \_\
";
    private readonly User user;
    
    
    public MainMenuView(User user)
    {
        this.user = user;
    }

    private void MainMenu()
    {
        Writer.PrintLine(asciString);
        Writer.PrintLine("PRESS 1 TO START      ");
        Writer.PrintLine("-------------------   ");
        Writer.PrintLine("PRESS 2 TO QUIT       ");
        Writer.PrintLine("--------------------- ");
        Writer.PrintLine("PRESS 3 for HIGHSCORES");
    }
    public void Draw()
    {
        MainMenu();
    }
    
    

    
}