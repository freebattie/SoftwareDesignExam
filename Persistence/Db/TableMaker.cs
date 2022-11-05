using Microsoft.Data.Sqlite;

namespace Persistence.Db {
    public class TableMaker {
        public static void UsersSchemaAndTableMaker() {
            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            CREATE TABLE IF NOT EXISTS users (
                name TEXT PRIMARY KEY NOT NULL,
                level INT,
                topscore INT 
            );            
        ";
            command.ExecuteNonQuery();
        }

        public static void WeaponsSchemaAndTableMaker() {
            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            CREATE TABLE IF NOT EXISTS weapons (
                id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                classname TEXT NOT NULL,
                description TEXT,
                damage INT 
            );            
        ";
            command.ExecuteNonQuery();
        }

        public static void ItemsSchemaAndTableMaker() {
            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            CREATE TABLE IF NOT EXISTS items (
                name TEXT PRIMARY KEY NOT NULL,
                itemlevel INT,
                gearspot INT,
                price INT 
            );            
        ";
            command.ExecuteNonQuery();
        }
    }
}