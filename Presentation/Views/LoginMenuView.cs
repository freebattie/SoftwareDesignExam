using Model.Base.Player;
using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;

namespace Presentation.Views {
    internal class LoginMenuView : IView {
        #region ascii picture
        private string _headerLogin = @"
  _      ____   _____        _____ _   _ 
 | |    / __ \ / ____|      |_   _| \ | |
 | |   | |  | | |  __         | | |  \| |
 | |   | |  | | | |_ |        | | | . ` |
 | |___| |__| | |__| |       _| |_| |\  |
 |______\____/ \_____|      |_____|_| \_|                                                                                                                                                                                                                                                                                                                                                                                       
";
        #endregion
        private ViewModel _vm;

        public void AddViewModel(ViewModel vm) {
           _vm = vm;
        }

        public void Draw() {
            PrintMenuName();
            if (_vm.Users != null)
                PrintMenu(_vm.Users);

        }

        private void PrintMenu(List<User> users) {
            Writer.PrintLine("Users that have been created:");
            foreach (var user in users) {
                Writer.PrintLine($"{user.Name} Level: {user.Level}");
            }
            Writer.PrintLine("entar a name to load in or a new name to start fresh");
            Writer.Print("Input:");
        }

        private void PrintMenuName() {
            Writer.ClearScreen();
            Writer.PrintLine(_headerLogin);
        }
    }
}
