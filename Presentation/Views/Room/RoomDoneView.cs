using Model.Base.Player;
using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;


namespace Presentation.Views.rooms
{
    internal class RoomDoneView : IView
    {
        #region ascii pictruee
        private readonly string _menu = @"
  _____   ____   ____  __  __    _____ _      ______          _____  ______ _____  
 |  __ \ / __ \ / __ \|  \/  |  / ____| |    |  ____|   /\   |  __ \|  ____|  __ \ 
 | |__) | |  | | |  | | \  / | | |    | |    | |__     /  \  | |__) | |__  | |  | |
 |  _  /| |  | | |  | | |\/| | | |    | |    |  __|   / /\ \ |  _  /|  __| | |  | |
 | | \ \| |__| | |__| | |  | | | |____| |____| |____ / ____ \| | \ \| |____| |__| |
 |_|  \_\\____/ \____/|_|  |_|  \_____|______|______/_/    \_\_|  \_\______|_____/ 
                                                                                   
                                                                                   
";
        #endregion

        private ViewModel _vm;

       
        public void Draw()
        {
            PrintMenuName();
            var playerHandler = _vm.Playerhandler;
            if (playerHandler != null)
                PrintMenu(playerHandler);
            else if (_vm.Room % 3 == 0)
                Writer.PrintLine($"3. To go too shop");
        }

        private void PrintMenuName()
        {
            Writer.ClearScreen();
            Writer.PrintLine(_menu);
        }

        private void PrintMenu(PlayerHandler playerhandler)
        {
            var player = playerhandler.GetPlayer();

            if (player != null)
            {
                Writer.PrintLine($"You beat room {_vm.Room}");
                Writer.PrintLine($"you are now level: {player.GetLevel()}");
                Writer.PrintLine($"you have: {_vm.Playerhandler.Money} money");
                Writer.PrintLine($"your current score is: {playerhandler.GetUser().CurrentScore}");
                Writer.PrintLine($"your best score is: {playerhandler.GetUser().Topscore}");
                Writer.PrintLine($"1. To go to next room");
                Writer.PrintLine($"2. To end run and go to main menu");
            }

        }

        public void AddViewModel(ViewModel vm) {
           _vm = vm;
        }
    }
}
