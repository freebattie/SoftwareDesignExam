﻿
using Microsoft.Data.Sqlite;
using Model.Base.Player;
using Model.Interface;

namespace Persistence.Db
{
    public class UserDao : IUserDao {

        public void AddUser(User user)
        {
            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            INSERT INTO users (name, level, topscore)
            VALUES ($name, $level, $topscore);
        ";
            command.Parameters.AddWithValue("$name", user.Name.ToLower());
            command.Parameters.AddWithValue("$level", user.Level);
            command.Parameters.AddWithValue("$topscore", user.Topscore);
            
            command.ExecuteNonQuery();
        }

        public User GetUser(string name)
        {
            User user = new();
            user.Level = 1;
            user.Topscore = 0;
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
                user.CurrentScore = 0;
            }
            else
            {
                user.Name = name;
                AddUser(user);
            }

            return user;
        }

        public void UpdateUser(User user, string newName)
        {
            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            UPDATE users SET name = $name, level = $level, topscore = $topscore 
                         WHERE name = $newName;
            VALUES ($name, $level, $topscore, $newName);
        ";
            command.Parameters.AddWithValue("$name", user.Name.ToLower());
            command.Parameters.AddWithValue("$level", user.Level);
            command.Parameters.AddWithValue("$topscore", user.Topscore);
           
            command.Parameters.AddWithValue("$newName", newName);
            command.ExecuteNonQuery();
        }
        
        public List<User> GetAllUsers()
        {
            List<User> usersList = new();

            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
                 SELECT * from users
             ";
            using SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new();
                    user.Name = reader.GetString(0);
                    user.Level = reader.GetInt32(1);
                    user.Topscore = reader.GetInt32(2);
                    user.CurrentScore = 0;
                    usersList.Add(user);    
                }
            }

            return usersList;
        }
        //TODO: Fjern
        public void DeleteUser()
        {
        }
    }
}