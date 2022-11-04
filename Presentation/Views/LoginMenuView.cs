using Model.Interface;
using Presentation.Utils;

namespace Presentation.Views {
    internal class LoginMenuView : IView {
       

        public void Draw() {
            Writer.PrintLine("enter a Username ");
            Writer.Print("input:");
        }
    }
}
