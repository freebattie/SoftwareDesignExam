
using Model.Base.Player;
using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;

namespace Presentation.Views {
    public class MainMenuView : IView {

        #region ascii picture
        private string _asciString = @"
  _____   ____  _    _  _____ ______      _____          _   _  _____ ______ _____  
 |  __ \ / __ \| |  | |/ ____|  ____|    |  __ \   /\   | \ | |/ ____|  ____|  __ \ 
 | |__) | |  | | |  | | |  __| |__       | |  | | /  \  |  \| | |  __| |__  | |__)|
 |  _  /| |  | | |  | | | |_ |  __|      | |  | |/ /\ \ | . ` | | |_ |  __| |  _  / 
 | | \ \| |__| | |__| | |__| | |____     | |__| / ____ \| |\  | |__| | |____| | \ \ 
 |_|  \_\\____/ \____/ \_____|______|    |_____/_/    \_\_| \_|\_____|______|_|  \_\
";
        #endregion

        private ViewModel _vm;

        public MainMenuView() {
            _vm = new();
        }

        private void MainMenu() {
            PrintGameName();
            PrintMenu();
        }

        private void PrintGameName() {
            Writer.ClearScreen();
            Writer.PrintLine(_asciString);
        }

        private static void PrintMenu() {
            Writer.PrintLine("PRESS 1 TO STARTGAME      ");
            Writer.PrintLine("-------------------   ");
            Writer.PrintLine("PRESS 2 TO QUIT       ");
            Writer.PrintLine("--------------------- ");
            Writer.PrintLine("PRESS 3 for HIGHSCORES");
            Writer.PrintLine("--------------------- ");
            Writer.PrintLine("PRESS 4 for DOWNLOAD UPDATES");
        }

        public void Draw() {
            MainMenu();
        }

        public void AddViewModel(ViewModel vm) {
            _vm = vm;
        }
    }
}