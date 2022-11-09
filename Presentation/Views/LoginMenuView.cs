using Model.Base.Player;
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
        private List<User>? users;

        public LoginMenuView() {
            
        }
        public LoginMenuView(List<User> users) {
            this.users = users;
        }

        public void Draw() {
            PrintMenuName();
            if (users != null)
                PrintMenu(users);

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
            Writer.PrintLine(headerLogin);
        }
    }
}
