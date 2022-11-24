using Model.Base.Enums;
using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;


namespace Presentation.Views {
    internal class DownloadView :IView {
        #region ascii picture
        private string menu = @"
  _____                      _                 _   _    _           _       _            
 |  __ \                    | |               | | | |  | |         | |     | |           
 | |  | | _____      ___ __ | | ___   __ _  __| | | |  | |_ __   __| | __ _| |_ ___  ___ 
 | |  | |/ _ \ \ /\ / / '_ \| |/ _ \ / _` |/ _` | | |  | | '_ \ / _` |/ _` | __/ _ \/ __|
 | |__| | (_) \ V  V /| | | | | (_) | (_| | (_| | | |__| | |_) | (_| | (_| | ||  __/\__ \
 |_____/ \___/ \_/\_/ |_| |_|_|\___/ \__,_|\__,_|  \____/| .__/ \__,_|\__,_|\__\___||___/
                                                         | |                             
                                                         |_|                             
";
        #endregion

        private ViewModel _vm;
        
        public DownloadView() {
            _vm= new ViewModel();
        }
        public void AddViewModel(ViewModel vm) {
            _vm = vm;
        }

        public void Draw() {

            Writer.ClearScreen();
            Writer.PrintLine(menu);
            Writer.PrintLine("0. to go back");
            Writer.PrintLine("1. to check for updates");


        }
    }
}

