using Model.Base.Enums;

namespace Model.Base.Shop

{
    public class ShopItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ItemLevel { get; set; }
        public GearSpot GearSpot { get; set; }
        public string Description { get; set; }
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

        public override string? ToString() {
            return $"Name: {Name}\n" +
                   $"Price: {Price}\n" +
                   $"Level: {ItemLevel}\n" +
                   $"Spot: {Enum.GetName(GearSpot)}";
        }
    }
}
