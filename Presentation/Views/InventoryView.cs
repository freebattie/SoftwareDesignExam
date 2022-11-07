using Model.Base.Enums;
using Model.Base.Shop;
using Model.Interface;
using Presentation.Utils;

namespace Presentation.Views {
    internal class InventoryView : IView {
        private List<ShopItem> items;
        private readonly Dictionary<GearSpot, ShopItem> activeItems;
        private string menu = @"
  _____ _   ___      ________ _   _ _______ ____  _______     __
 |_   _| \ | \ \    / /  ____| \ | |__   __/ __ \|  __ \ \   / /
   | | |  \| |\ \  / /| |__  |  \| |  | | | |  | | |__) \ \_/ / 
   | | | . ` | \ \/ / |  __| | . ` |  | | | |  | |  _  / \   /  
  _| |_| |\  |  \  /  | |____| |\  |  | | | |__| | | \ \  | |   
 |_____|_| \_|   \/   |______|_| \_|  |_|  \____/|_|  \_\ |_|   
                                                                
                                                                
";
        public InventoryView(List<ShopItem> inventory,Dictionary<GearSpot,ShopItem> activeItems) {

            this.items = inventory;
            this.activeItems = activeItems;
        }

        public InventoryView() {
        }

        public void DrawInvetory() {
            Writer.ClearScreen();
            Writer.PrintLine(menu,ConsoleColor.DarkCyan);
            int index = 1;
            Writer.PrintLine("Your Invetory");
            foreach (var item in items) {
                ItemsList(index, item);
                index++;
            }
            var index2 = 1;
            Writer.PrintLine("Equipt items:");
            foreach (var item in activeItems.Values) {
                ItemsList(index2, item);
                index2++;
            }
            Writer.PrintLine($"select a invetory item to put on enter {index} when done");
        }

        private static void ItemsList(int index, ShopItem item) {
            Writer.PrintLine($"######################################## ITEM {index} ######################################## \nGearspot: {item.GearSpot} \nName: {item.Name} \nValue: [{item.Price}] \nDescription: {item.Description}");
            Writer.PrintLine("########################################################################################");
           
        }

        public void Draw() {
            DrawInvetory();
        }
    }
}
