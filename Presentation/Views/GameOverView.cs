using Model.Base.Player;
using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;

namespace Presentation.Views {
    public class GameOverView : IView {
        #region ascii picture

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
        #endregion

        private ViewModel _vm;

        public GameOverView() {
            _vm = new ViewModel();
        }
        public void GameOverMenu() {
            Writer.ClearScreen();
            if (_vm.Playerhandler.GetUser() != null) 
                PrintMenu(_vm.Playerhandler.GetUser());
        }

        private void PrintMenu(User user) {
            Writer.PrintLine(asciGraphic, ConsoleColor.Red);
            Writer.PrintLine("----------------------------");
            Writer.PrintLine("----------GAME RESULT-------");
            Writer.PrintLine($"PLAYER LEVEL  {user.Level} ");
            Writer.PrintLine("----------------------------");
            Writer.PrintLine("PRESS 1 TO RESTART          ");
            Writer.PrintLine("----------------------------");
            Writer.PrintLine("PRESS 2 TO QUIT             ");
            Writer.PrintLine("----------------------------");
            Writer.PrintLine("PRESS 3 FOR MAINMENU          ");
            Writer.PrintLine("----------------------------");
        }

        public void Draw() {
            GameOverMenu();
        }

        public void AddViewModel(ViewModel vm) {
           _vm = vm;
        }
    }
}