using Microsoft.Data.Sqlite;
using Model.Base;
using Model.Factory;
using Model.Interface;

namespace Persistence.Db;

public class WeaponDao : IWeaponDao
{
    public void AddWeapon(Weapon weapon)
    {
        using SqliteConnection connection = new("Data Source = gameDb.db");
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO weapons (damage, description)
            VALUES ($damage, $description);
        ";
        command.Parameters.AddWithValue("$damage", weapon.Damage);
        command.Parameters.AddWithValue("$description", weapon.Description);
        command.ExecuteNonQuery();
    }

    public List<Weapon> GetAllWeapons()
    {
        List<Weapon> weaponsList = new();

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
                Weapon weapon = new();
                weapon.Damage = reader.GetInt32(0);
                weapon.Description = reader.GetString(1);
            }
        }

        return weaponsList;
    }
}