using Model.Base.Shop;
using Model.Base.ViewModel;
using Model.Interface;
using Presentation.Utils;

namespace Presentation.Views {
    internal class InventoryView : IView {
        
        #region ascii picture  
        private string _menu = @"
  _____ _   ___      ________ _   _ _______ ____  _______     __
 |_   _| \ | \ \    / /  ____| \ | |__   __/ __ \|  __ \ \   / /
   | | |  \| |\ \  / /| |__  |  \| |  | | | |  | | |__) \ \_/ / 
   | | | . ` | \ \/ / |  __| | . ` |  | | | |  | |  _  / \   /  
  _| |_| |\  |  \  /  | |____| |\  |  | | | |__| | | \ \  | |   
 |_____|_| \_|   \/   |______|_| \_|  |_|  \____/|_|  \_\ |_|   
                                                                
                                                                
";
        private string _activeGear = @"
    _   ___ _____ _____   _____    ___ ___   _   ___ 
   /_\ / __|_   _|_ _\ \ / | __|  / __| __| /_\ | _ \
  / _ | (__  | |  | | \ V /| _|  | (_ | _| / _ \|   /
 /_/ \_\___| |_| |___| \_/ |___|  \___|___/_/ \_|_|_\
                                                     
";
        private string _backpack = @"
  ___   _   ___ _  _____  _   ___ _  __
 | _ ) /_\ / __| |/ | _ \/_\ / __| |/ /
 | _ \/ _ | (__| ' <|  _/ _ | (__| ' < 
 |___/_/ \_\___|_|\_|_|/_/ \_\___|_|\_\
                                       
";
        #endregion

        private ViewModel _vm;

       
       
        public void DrawInvetory() {
            Writer.ClearScreen();
            Writer.PrintLine(_menu,ConsoleColor.DarkCyan);
            int index = 1;
            Writer.PrintLine(_backpack, ConsoleColor.Blue);
            foreach (var item in _vm.Playerhandler.GetInventory()) {
                ItemsList(index, item);
                index++;
            }
            var index2 = 1;
            Writer.PrintLine("");
            Writer.PrintLine(_activeGear,ConsoleColor.Green);
            foreach (var item in _vm.Playerhandler.GetActiveItems().Values) {
                ItemsList(index2, item);
                index2++;
            }
            Writer.PrintLine("");
            Writer.PrintLine("");
            Writer.PrintLine($"select a invetory item to put on enter 0 when done");
        }

        private static void ItemsList(int index, ShopItem item) {
            Writer.PrintLine($"######################################## ITEM {index} ######################################## \nGearspot: {item.GearSpot} \nName: {item.Name} \nValue: [{item.Price}] \nDescription: {item.Description}");
            Writer.PrintLine("########################################################################################");
           
        }

        public void Draw() {
            DrawInvetory();
        }

        public void AddViewModel(ViewModel vm) {
            _vm = vm;
            
        }
    }
}
