

using Model.Base.Enums;
using Model.Interface;

namespace Model.Base.Shop
{
    public static class ShopItemSpawner {
        private static List<ShopItem>? invetory;

        /// <summary>
        /// lager til en liste med alle items i spillet
        /// </summary>
        /// <returns></returns>
        public static void SetAllShopItems(List<ShopItem> items) {
            invetory = items;   
        }
        /// <summary>
        /// genere angitte items, men kun 1 av hver slot
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Dictionary<GearSpot, ShopItem> GetRandomActiveItems(int items) {
            
            var allspots = Enum.GetNames(typeof(GearSpot));
            items = items <= allspots.Length ? items : allspots.Length;
            Dictionary<GearSpot, ShopItem> inventory = new Dictionary<GearSpot, ShopItem>();
           
            while (items > 0) { 
            
                Random rand = new Random();

                //Trenger ingen sjekk her siden vi lager Dictionary rett før loopen;
                var count = invetory.Count;
                var index = rand.Next(count);
                var tmpItem = invetory?[index];

                //Trenger ikke å sjekke for null her siden vi sjekker antall i Dictionary
                //og vi bruker not null pattern på items 
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
        /// <summary>
        /// henter ut angitt antall items, kan få like "gear spot" å like items.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<ShopItem> GetRandomListOfItems(int items) {

            var allspots = Enum.GetNames(typeof(GearSpot));
            items = items <= allspots.Length ? items : allspots.Length;
            List<ShopItem> inventory = new ();

            while (items > 0) {

                Random rand = new Random();
                var index = rand.Next(invetory.Count);
                var tmpItem = invetory[index];
                inventory.Add( tmpItem);
                items--;
            }



            return inventory;
        }
    }
}
