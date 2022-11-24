using Model.Base.Player;
using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views {
    internal class HighScoreView : IView {
      
        private string _header = @"
  _    _ _____ _____ _    _    _____  _____ ____  _____  ______ 
 | |  | |_   _/ ____| |  | |  / ____|/ ____/ __ \|  __ \|  ____|
 | |__| | | || |  __| |__| | | (___ | |   | |  | | |__) | |__   
 |  __  | | || | |_ |  __  |  \___ \| |   | |  | |  _  /|  __|  
 | |  | |_| || |__| | |  | |  ____) | |___| |__| | | \ \| |____ 
 |_|  |_|_____\_____|_|  |_| |_____/ \_____\____/|_|  \_\______|
                                                                
                                                                
";
        private ViewModel _vm;

      

        public void AddViewModel(ViewModel vm) {
            _vm = vm;
        }

        public void Draw() {
            var users = _vm.Users;
            Writer.ClearScreen();

            Writer.PrintLine(_header);
            int index = 1;
            users.Sort((i, b) => { return i.Topscore <= b.Topscore ? 1 : -1; });
            foreach (var user in users) {
                Writer.PrintLine($"{index}. {user.Name} Score: {user.Topscore}");
                index++;
            }
          
            Writer.PrintLine("Press a key to go back to main menu");
        }
    }
}
