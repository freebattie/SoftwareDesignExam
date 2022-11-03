using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views {
    internal class LoginMenuView : IView {
        public void Draw() {
            Writer.PrintLine("enter a Username ");
            Writer.Print("input:");
        }
    }
}
