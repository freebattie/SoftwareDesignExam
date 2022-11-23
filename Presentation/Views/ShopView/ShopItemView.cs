using Model.Base.Shop;
using Model.Interface;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views.ShopView {
    internal class ShopItemView : IView {
        private readonly List<ShopItem> allItems;

        public ShopItemView() {

        }
        public ShopItemView(List<ShopItem> allItems) {
            this.allItems = allItems;
        }
      
        public void Draw() {
            int index = 1;
            Writer.ClearScreen();
            Writer.PrintLine("0. to continue");
            foreach (var item in allItems) {
                Writer.PrintLine($"{index}. Name: {item.Name}  Gearspot: {item.GearSpot}  Lvl: {item.ItemLevel} Price:{item.Price}" +
                    $"/nDecription: {item.Description}");
                Writer.PrintLine("");
                index++;
            }
           
        }
    }
}
