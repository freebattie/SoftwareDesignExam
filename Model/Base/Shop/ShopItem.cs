using Model.Base.Enums;

namespace Model.Base.Shop
{
    /// <summary>
    /// Used as a wrapper class to show info for item classes in the game to the user and for the decorator factory
    /// to use to decorate the player
    /// </summary>
    public class ShopItem
    {
        #region props
        public string Name { get; set; }
        public int Price { get; set; }
        public int ItemLevel { get; set; }
        public GearSpot GearSpot { get; set; }
        public string Description { get; set; }
        #endregion

        #region constructors
        public ShopItem() {
            Name = "";
            Description = "";
            GearSpot = GearSpot.NONE;
        }
        public ShopItem(string name, int price, int itemLevel, GearSpot gearSpot, string description) {
            Name = name;
            Price = price;
            ItemLevel = itemLevel;
            GearSpot = gearSpot;
            Description = description;
            
        }
        #endregion

        #region overrides
        public override string? ToString() {
            return $"Name: {Name}\n" +
                   $"Price: {Price}\n" +
                   $"Level: {ItemLevel}\n" +
                   $"Spot: {Enum.GetName(GearSpot)}";
        }
        #endregion
    }
}
