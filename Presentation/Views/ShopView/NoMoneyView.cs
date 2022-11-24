using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views.ShopView {
    internal class NoMoneyView: IView {
        private ViewModel _vm;

        public void AddViewModel(ViewModel vm) {
            _vm = vm;
        }

        public void Draw() {
            int index = 1;
            Writer.ClearScreen();
            Writer.PrintLine("You cant afford that");
            Writer.PrintLine("Press a key to continue");
           

        }
    }
}
