using Microsoft.Data.Sqlite;
using Model.Base.Enums;
using Model.Base.Shop;
using Model.Interface;

namespace Persistence.Db {
    public class ItemDao : IItemDao {


        public List<Model.Base.Shop.ShopItem> GetAllItems() {
            List<Model.Base.Shop.ShopItem> shopItemList = new();

            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            SELECT * from items
        ";
            using SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    Model.Base.Shop.ShopItem item = new();
                    item.Name = reader.GetString(0);
                    item.Description = reader.GetString(1);
                    item.ItemLevel = reader.GetInt32(2);
                    item.GearSpot = (GearSpot)reader.GetInt32(3);
                    item.Price = reader.GetInt32(4);
                    shopItemList.Add(item);

                }
            }
            if (shopItemList.Count == 0)
                return new() {new Model.Base.Shop.ShopItem("noitem",2,2, GearSpot.GLOVES,"Item not found") };

            return shopItemList;
        }

        //TODO: REMOVE
        public void AddItem(Model.Base.Shop.ShopItem item) {
            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            INSERT INTO items (name, itemlevel, gearspot, price)
            VALUES ($name, $itemlevel, $gearspot, $price);
        ";
            command.Parameters.AddWithValue("$name", item.Name);
            command.Parameters.AddWithValue("$itemlevel", item.ItemLevel);
            command.Parameters.AddWithValue("$gearspot", item.GearSpot);
            command.Parameters.AddWithValue("$price", item.Price);
            command.ExecuteNonQuery();
        }
    }
}