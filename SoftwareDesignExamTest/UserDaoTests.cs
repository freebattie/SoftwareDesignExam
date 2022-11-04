using Microsoft.Data.Sqlite;
using Persistence.Db;

namespace SoftwareDesignExamTest
{
    public class UserDaoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        UserDao userDao = new();
        [Test]
        public void GetUser()
        { 
            TableMaker.UsersSchemaAndTableMaker();

            User user = userDao.GetUser("Test");

            Assert.That(user.Name, Is.EqualTo("Test"));
        }
    }
}