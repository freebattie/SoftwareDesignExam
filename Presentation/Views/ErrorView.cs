using Model.Interface;
using Presentation.Utils;

namespace Presentation.Views;

public class ErrorView : IView
{
    private string errorHeader = @"
  ______ _____  _____   ____  _____  
 |  ____|  __ \|  __ \ / __ \|  __ \ 
 | |__  | |__) | |__) | |  | | |__) |
 |  __| |  _  /|  _  /| |  | |  _  / 
 | |____| | \ \| | \ \| |__| | | \ \ 
 |______|_|  \_\_|  \_\\____/|_|  \_\
                                     
";
    public void Draw()
    {
        Writer.ClearScreen();
        
        Writer.PrintLine(errorHeader);
        Writer.PrintLine("");
        Writer.PrintLine("");
        Writer.Print("You have ");
        Writer.Print("ERROR", ConsoleColor.DarkRed);
        Writer.Print(" in your input.");
        Writer.PrintLine("");
        Writer.PrintLine("");
        Writer.PrintLine("You can choose from following options:");
        Writer.PrintLine("1. Go back");
        Writer.PrintLine("2. Quit game");
    }
}