using System.Diagnostics.Tracing;
using Microsoft.Data.Sqlite;
using Model.Base;
using Model.Enums;
using Model.Interface;

namespace Persistence.Db;

public class ItemDao : IItemDao
{
    
    
    public List<ShopItem> GetAllItems()
    {
        List<ShopItem> shopItemList = new();
        
        using SqliteConnection connection = new("Data Source = gameDb.db");
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            SELECT * from items
        ";
        using SqliteDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                ShopItem item = new();
                item.Name = reader.GetString(0);
                item.ItemLevel = reader.GetInt32(1);
                item.GearSpot = (GearSpot)reader.GetInt32(2);
                item.Price = reader.GetInt32(3);
                shopItemList.Add(item);
           
            }
        }
        return shopItemList;
    }
    

    public void AddItem(ShopItem item)
    {
        using SqliteConnection connection = new("Data Source = gameDb.db");
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO items (name, itemlevel, gearspot, price)
            VALUES ($name, $itemlevel, $gearspot, $price);
        ";
        command.Parameters.AddWithValue("$name", item.Name);
        command.Parameters.AddWithValue("$itemlevel", item.ItemLevel );
        command.Parameters.AddWithValue("$gearspot", item.GearSpot);
        command.Parameters.AddWithValue("$price", item.Price);
        command.ExecuteNonQuery();
    }
}