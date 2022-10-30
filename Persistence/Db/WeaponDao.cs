using System.Data;
using Microsoft.Data.Sqlite;
using Model.Factory;
using Model.Interface;

namespace Persistence.Db;

public class WeaponDao : IWeaponDao
{
    public List<IWeapon> GetAllWeapons()
    {
        List<IWeapon> weaponList = new();
        using SqliteConnection connection = new("Data Source = gameDb.db");
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            SELECT * from weapons
        ";
        using SqliteDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                weaponList.Add(WeaponFactory.GetWeapon(
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetInt32(3)
                ));
            }
        }
        return weaponList;
    }

    public void AddWeapon(string classname, string description, int damage)
    {
        using SqliteConnection connection = new("Data Source = gameDb.db");
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO weapons (classname, description, damage)
            VALUES ($classname, $description, $damage  );
        ";
        command.Parameters.AddWithValue("$classname", classname);
        command.Parameters.AddWithValue("$description", description);
        command.Parameters.AddWithValue("$damage", damage);
        command.ExecuteNonQuery();
    }
}