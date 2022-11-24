using Model.Base.Shop;
using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views.ShopView {
    internal class ShopItemView : IView {
        private ViewModel _vm;

        public void AddViewModel(ViewModel vm) {
           _vm = vm;
        }

        private void ShowPlayerInfo() {
            var weapon = _vm.Playerhandler.GetPlayer().GetWeapon();
            Writer.PrintLine($"You have: {_vm.Playerhandler.Money} Money");
           
        }

        public void Draw() {
            int index = 1;
            Writer.ClearScreen();
            ShowPlayerInfo();
            Writer.PrintLine("0. back to shop");
            Writer.PrintLine($"[1-{_vm.Items.Count}] to buy");
            foreach (var item in _vm.Items) {
                Writer.PrintLine($"############################## ITEM :{index} ##############################");
                Writer.PrintLine($"#Name: {item.Name}  Gearspot: {item.GearSpot}  Lvl: {item.ItemLevel} Price:{item.Price}" +
                    $"#\nDecription: {item.Description}");
                Writer.PrintLine($"#################################################################");
                Writer.PrintLine("");
                index++;
            }
           
        }
    }
}
