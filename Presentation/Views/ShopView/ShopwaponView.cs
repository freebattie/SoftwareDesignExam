using Model.Base;
using Model.Base.Shop;
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
    internal class ShopWeaponView : IView
    {
        
        
        private ViewModel? _vm;

        public void Draw() {
            Writer.ClearScreen();
            int index = 1;
            ShowPlayerInfo();
            Writer.PrintLine("write 0 for back");
            Writer.PrintLine($"[1-{_vm.Weapons.Count}] to buy");
            Writer.PrintLine("");
            foreach (var weapon in _vm.Weapons) {
                Writer.PrintLine($"############################## ITEM :{index} ##############################");
                Writer.PrintLine($"#Name: {weapon.Name} dmg: {weapon.Damage} Price: {weapon.Price}" +
                    $"#\nDecription: {weapon.Description}");
                Writer.PrintLine($"#################################################################");
                index++;
            }

        }

        private void ShowPlayerInfo() {
            var weapon = _vm.Playerhandler.GetPlayer().GetWeapon();
            Writer.PrintLine($"You have: {_vm.Playerhandler.Money} Money");
            Writer.PrintLine($"Your current weapon: {weapon.Name} dmg: {weapon.Damage}");
        }

        public void AddViewModel(ViewModel vm) {
          _vm = vm;
        }
    }
}
