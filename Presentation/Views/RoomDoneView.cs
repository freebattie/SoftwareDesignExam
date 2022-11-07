using Model.Base.Player;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views {
    internal class RoomDoneView : IView {
        private readonly PlayerHandler playerhandler;
        private readonly int room;
        private readonly string menu = @"
  _____   ____   ____  __  __    _____ _      ______          _____  ______ _____  
 |  __ \ / __ \ / __ \|  \/  |  / ____| |    |  ____|   /\   |  __ \|  ____|  __ \ 
 | |__) | |  | | |  | | \  / | | |    | |    | |__     /  \  | |__) | |__  | |  | |
 |  _  /| |  | | |  | | |\/| | | |    | |    |  __|   / /\ \ |  _  /|  __| | |  | |
 | | \ \| |__| | |__| | |  | | | |____| |____| |____ / ____ \| | \ \| |____| |__| |
 |_|  \_\\____/ \____/|_|  |_|  \_____|______|______/_/    \_\_|  \_\______|_____/ 
                                                                                   
                                                                                   
";
        public RoomDoneView() { }
        public RoomDoneView(PlayerHandler playerhandler,int room) {
            this.playerhandler = playerhandler;
            this.room = room;
            
        }
        public void Draw() {
            Writer.ClearScreen();
            Writer.PrintLine(menu);
            Writer.PrintLine($"You beat room {room}");
            Writer.PrintLine($"you are now level: {playerhandler.GetPlayer().GetLevel()}");
            Writer.PrintLine($"your current score is: {playerhandler.GetUser().CurrentScore}");
            Writer.PrintLine($"your best score is: {playerhandler.GetUser().Topscore}");
            Writer.PrintLine($"1. To go to next room");
            Writer.PrintLine($"2. To end run and go to main menu");
            //Writer.PrintLine($"3. To go too shop");
        }
    }
}
