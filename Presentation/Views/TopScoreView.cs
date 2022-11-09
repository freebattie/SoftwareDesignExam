using Model.Base.Player;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views {
    internal class HighScoreView : IView {
        private readonly List<User> _users;
        private string _header = @"
  _    _ _____ _____ _    _    _____  _____ ____  _____  ______ 
 | |  | |_   _/ ____| |  | |  / ____|/ ____/ __ \|  __ \|  ____|
 | |__| | | || |  __| |__| | | (___ | |   | |  | | |__) | |__   
 |  __  | | || | |_ |  __  |  \___ \| |   | |  | |  _  /|  __|  
 | |  | |_| || |__| | |  | |  ____) | |___| |__| | | \ \| |____ 
 |_|  |_|_____\_____|_|  |_| |_____/ \_____\____/|_|  \_\______|
                                                                
                                                                
";

        public HighScoreView() {
            _users = new();
        }
        public HighScoreView(List<User> users ) {
            this._users = users;
        }
        public void Draw() {

            Writer.ClearScreen();

            Writer.PrintLine(_header);
            int index = 1;
            _users.Sort((i, b) => { return i.Topscore <= b.Topscore ? 1 : -1; });
            foreach (var user in _users) {
                Writer.PrintLine($"{index}. {user.Name} Score: {user.Topscore}");
                index++;
            }
          
            Writer.PrintLine("Press a key to go back to main menu");
        }
    }
}
