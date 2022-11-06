using Model.Base.Enums;
using Model.Base.Shop;
using Model.Interface;
using Presentation.Utils;

namespace Presentation.Views {
    internal class InventoryView : IView {
        private List<ShopItem> items;
        private readonly Dictionary<GearSpot, ShopItem> activeItems;

        public InventoryView(List<ShopItem> inventory,Dictionary<GearSpot,ShopItem> activeItems) {

            this.items = inventory;
            this.activeItems = activeItems;
        }

        public InventoryView() {
        }

        public void DrawInvetory() {
            Writer.ClearScreen();
            int index = 1;
            Writer.PrintLine("Your Invetory");
            foreach (var item in items) {
                Writer.PrintLine($"{index}.[{item.GearSpot.ToString()}] [{item.Name}] value: [{item.Price}] Description: {item.Description}");
                index++;
            }
            var index2 = 1;
            Writer.PrintLine("Equipt items:");
            foreach (var item in activeItems.Values) {
                Writer.PrintLine($"{index2}.[{item.GearSpot.ToString()}] [{item.Name}] value: [{item.Price}] ");
                index2++;
            }
            Writer.PrintLine($"select a invetory item to put on enter {index} when done");
        }
        public void Draw() {
            DrawInvetory();
        }
    }
}
