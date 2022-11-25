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
        private string _backpack = @"
  ___   _   ___ _  _____  _   ___ _  __
 | _ ) /_\ / __| |/ | _ \/_\ / __| |/ /
 | _ \/ _ | (__| ' <|  _/ _ | (__| ' < 
 |___/_/ \_\___|_|\_|_|/_/ \_\___|_|\_\
                                       
";
        private string _shop = @"
  _____ _______ ______ __  __  _____   ______ ____  _____     _____         _      ______ 
 |_   _|__   __|  ____|  \/  |/ ____| |  ____/ __ \|  __ \   / ____|  /\   | |    |  ____|
   | |    | |  | |__  | \  / | (___   | |__ | |  | | |__) | | (___   /  \  | |    | |__   
   | |    | |  |  __| | |\/| |\___ \  |  __|| |  | |  _  /   \___ \ / /\ \ | |    |  __|  
  _| |_   | |  | |____| |  | |____) | | |   | |__| | | \ \   ____) / ____ \| |____| |____ 
 |_____|  |_|  |______|_|  |_|_____/  |_|    \____/|_|  \_\ |_____/_/    \_\______|______|
                                                                                          
                                                                                          
";

        public void AddViewModel(ViewModel vm) {
           _vm = vm;
        }

        private void ShowPlayerInfo() {
            var weapon = _vm.Playerhandler.GetPlayer().GetWeapon();
            Writer.PrintLine($"You have: {_vm.Playerhandler.Money} Money");
            int index = 1;
            Writer.PrintLine(_backpack, ConsoleColor.Blue);
            foreach (var item in _vm.Playerhandler.GetInventory()) {
                ItemsList(index, item);
                index++;
            }

        }
        private static void ItemsList(int index, ShopItem item) {
            Writer.PrintLine($"######################################## ITEM {index} ######################################## \nGearspot: {item.GearSpot} \nName: {item.Name} \nValue: [{item.Price}] \nDescription: {item.Description}");
            Writer.PrintLine("########################################################################################");
           
        }
        public void Draw() {
            int index = 1;
            Writer.ClearScreen();
            ShowPlayerInfo();
            Writer.PrintLine("");
            Writer.PrintLine(_shop);
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
