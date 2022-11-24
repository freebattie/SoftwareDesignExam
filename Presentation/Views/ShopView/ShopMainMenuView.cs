using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views.ShopView
{
    internal class ShopMainMenuView : IView {
        private ViewModel _vm;
        public void Draw()
        {
            Writer.ClearScreen();
            Writer.PrintLine(building);
            Writer.PrintLine("SHOP MENU");

            Writer.PrintLine("0. To continue game");
            Writer.PrintLine("1. weapons for sale");
            Writer.PrintLine("2. items for sale");

        }

        public void AddViewModel(ViewModel vm) {
           _vm = vm;
        }

        string building = @" ^             ^               ^!^
   ^ _______________________________
    [=U=U=U=U=U=U=U=U=U=U=U=U=U=U=U=]
    |.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.|
    |        +-+-+-+-+-+-+-+-+      |
    |        |Weapons & Items|      |
    |        +-+-+-+-+-+-+-+-+      |
    |.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.|
    |  _________  __ __  _________  |
  _ | |___   _  ||[]|[]||  _      | | _
 (!)||OPEN|_(!)_|| ,| ,||_(!)_____| |(!)
.T~T|:.....:T~T.:|__|__|:.T~T.:....:|T~T.
||_||||||||||_|||||||||||||_||||||||||_||
~\=/~~~~~~~~\=/~~~~~~~~~~~\=/~~~~~~~~\=/~
  | -------- | ----------- | -------- |
~ |~^ ^~~^ ~~| ~^  ~~ ^~^~ |~ ^~^ ~~^ |^~";
       
    }
}
