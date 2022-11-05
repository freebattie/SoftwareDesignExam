using Microsoft.Data.Sqlite;
using Model.Base.Player;
using Persistence.Db;

namespace SoftwareDesignExamTest
{
    public class UserDaoTests
    {
        [SetUp]
        public void Setup()
        {
            TableMaker.UsersSchemaAndTableMaker();
        }

        [TearDown]
        public void TearDown()
        {
            using SqliteConnection connection = new("Data Source = gameDb.db");
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"
            DROP TABLE IF EXISTS users            
        ";
            command.ExecuteNonQuery();
        }
        
        UserDao userDao = new();

        [Test]
        public void GetAndAddUserTest()
        {
            User user = new("Test1", 3, 100, 20);
            userDao.AddUser(user);
            User userOutput = userDao.GetUser("Test1");
            Assert.That(userOutput.Level.Equals(3));
        }

        [Test]
        public void UpdateUserTest()
        {
            User oldUser = userDao.GetUser("Test1");
            oldUser.Name = "UpdatedName";
            userDao.UpdateUser(oldUser, "Test1");

            Assert.That(oldUser.Name.Equals("UpdatedName"));
        }
    }
}