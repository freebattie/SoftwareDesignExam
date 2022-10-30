using Microsoft.Data.Sqlite;
using Model.Base;
using Model.Interface;


namespace Persistence.Db
{
    public class UserDAO : IUserDAO
    {
        public void AddUser(User user)
        {
            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            INSERT INTO users (name, level, topscore)
            VALUES ($name, $level, $topscore);
        ";
            command.Parameters.AddWithValue("$name", user.Name);
            command.Parameters.AddWithValue("$level", user.Level);
            command.Parameters.AddWithValue("$topscore", user.Topscore);
            command.ExecuteNonQuery();
        }
        
        public User GetUser(string? name)
        {
            User user = new();
            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            SELECT name, level, topscore
            FROM users 
            WHERE name = $name
        ";
            command.Parameters.AddWithValue("$name", name);
            using SqliteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user.Name = reader.GetString(0);
                user.Level = reader.GetInt32(1);
                user.Topscore = reader.GetInt32(2);
            }

            return user;
        }
        
        
        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser()
        {
        }
    }
}