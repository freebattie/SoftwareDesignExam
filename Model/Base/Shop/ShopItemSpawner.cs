

using Model.Base.Enums;
using Model.Interface;

namespace Model.Base.Shop
{
    public static class ShopItemSpawner {
        private static List<ShopItem> invetory;

        /// <summary>
        /// lager til en liste med alle items i spillet
        /// </summary>
        /// <returns></returns>
        public static void SetAllShopItems(List<ShopItem> items) {
            invetory = items;
/*
            List<ShopItem> invetory = new();
            ShopItem item = new();
            item.Price = 100;
            item.GearSpot = GearSpot.TRINCKET;
            item.ItemLevel = 1;
            item.Description = "Stops user from dieing from a leathal blow one time";
            item.Name = "rabbitsfoot";
            invetory.Add(item);

            item = new();
            item.GearSpot = GearSpot.SHIELD;
            item.Price = 100;
            item.ItemLevel = 1;
            item.Description = "removes 1 damage from each attack utill it breaks after 10 dmg";
            item.Name = "woodenshield";
            invetory.Add(item);

            item = new();
            item.GearSpot = GearSpot.SHIELD;
            item.Price = 100;
            item.ItemLevel = 1;
            item.Description = "removes 5 damage from each attack utill it breaks after 40 dmg";
            item.Name = "ironshield";
            invetory.Add(item);

            item = new();
            item.GearSpot = GearSpot.HELMET;
            item.Price = 100;
            item.ItemLevel = 1;
            item.Description = "removes 5 damage from each attack utill it breaks after 40 dmg";
            item.Name = "wikinghelmet";

            invetory.Add(item);
            item = new();
            item.GearSpot = GearSpot.GLOVES;
            item.Price = 100;
            item.ItemLevel = 1;
            item.Description = "You heal instead of take damage, 3 uses";
            item.Name = "knightgloves";
            invetory.Add(item);*/

            
        }

        public static Dictionary<GearSpot, ShopItem> GetARandomInventory(int items) {
            
            var allspots = Enum.GetNames(typeof(GearSpot));
            items = items <= allspots.Length ? items : allspots.Length;
            Dictionary<GearSpot, ShopItem> inventory = new Dictionary<GearSpot, ShopItem>();
           
            while (items > 0) { 
            
                Random rand = new Random();
                var index = rand.Next(invetory.Count);
                var tmpItem = invetory[index];
                if (inventory.ContainsKey(tmpItem.GearSpot)) {
                    continue;
                }
                else {
                    inventory.Add(tmpItem.GearSpot, tmpItem);
                    items--;
                }
            }


            return inventory;
        }
    }
}
