using Model.Interface;
using Presentation.Utils;

namespace Presentation.Views {
    internal class LoginMenuView : IView {
        private string headerLogin = @"
  _      ____   _____        _____ _   _ 
 | |    / __ \ / ____|      |_   _| \ | |
 | |   | |  | | |  __         | | |  \| |
 | |   | |  | | | |_ |        | | | . ` |
 | |___| |__| | |__| |       _| |_| |\  |
 |______\____/ \_____|      |_____|_| \_|                                                                                                                                                                                                                                                                                                                                                                                       
";
        public void Draw() {
            Writer.ClearScreen();
            Writer.PrintLine(headerLogin);
            Writer.PrintLine("Enter a username to start the game");
            Writer.PrintLine("Input:");
        }
    }
}
