

using Model.Base.Enums;
using Model.Interface;

namespace Model.Base.Shop
{
    public static class ShopItemSpawner {
        private static List<ShopItem> _invetory;

        /// <summary>
        /// lager til en liste med alle items i spillet
        /// </summary>
        /// <returns></returns>
        public static void SetAllShopItems(List<ShopItem> items) {
            _invetory = items;   
        }
        static ShopItemSpawner() {
            _invetory = new();
}
        /// <summary>
        /// genere angitte items, men kun 1 av hver slot
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Dictionary<GearSpot, ShopItem> GetRandomActiveItems(int items) {
            
            var allspots = Enum.GetNames(typeof(GearSpot));
            items = items <= allspots.Length ? items : allspots.Length;
            Dictionary<GearSpot, ShopItem> invetory = new Dictionary<GearSpot, ShopItem>();
           
            while (items > 0) { 
            
                Random rand = new Random();

                //Trenger ingen sjekk her siden vi lager Dictionary rett før loopen;
                if (invetory != null && _invetory != null ) {
                    var count = _invetory.Count;
                    var index = rand.Next(count);
                    var tmpItem = _invetory?[index];
                    if (tmpItem !=null) {
                        //Trenger ikke å sjekke for null her siden vi sjekker antall i Dictionary
                        //og vi bruker not null pattern på items 
                        if (invetory.ContainsKey(tmpItem.GearSpot)) {
                            continue;
                        }
                        else {
                            invetory.Add(tmpItem.GearSpot, tmpItem);
                            items--;
                        }
                    }

                    
                }
                
            }



            return invetory != null ? invetory : new();
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
                var index = rand.Next(_invetory.Count);
                var tmpItem = _invetory[index];
                inventory.Add( tmpItem);
                items--;
            }



            return inventory;
        }
    }
}
