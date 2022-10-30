using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Base
{
    public class ShopItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ItemLevel { get; set; }
        public GearSpot GearSpot { get; set; }
        public ShopItem() {

        }
        public ShopItem(string name, int price, int itemLevel, GearSpot gearSpot) {
            Name = name;
            Price = price;
            ItemLevel = itemLevel;
            GearSpot = gearSpot;
        }

        public override string? ToString() {
            return $"Name: {Name}\n" +
                   $"Price: {Price}\n" +
                   $"Level: {ItemLevel}\n" +
                   $"Spot: {Enum.GetName(GearSpot)}";
        }
    }
}
