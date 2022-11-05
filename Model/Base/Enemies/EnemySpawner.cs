

using Model.Base.Player;
using Model.Base.Shop;
using Model.Decorator.Abstract;
using Model.Decorator.Original;
using Model.Factory;
using Model.Interface;

namespace Model.Base.Enemies
{
    public class EnemySpawner
    {
        
        
        private static string[] enemyRace = { "Orc", "Elf", "Giant", "Wearvolf", "RockMonster", "Wampire", };
        private static string[] enemyTypes = { "Shaman", "Priest", "Knight", "Worrior", "King", "Commander", };
        

        public static List<Character> SpawnEnemies(int nrOfEnemies, int level)
        {
            List<Character> enemies = new ();
           
             
            var allItems = ItemDecoratorFactory.GetNameOFAllItemsInGame();
           
            for (int i = 0; i < nrOfEnemies; i++)
            {
                Random random = new Random();
                var race = random.Next(enemyTypes.Length);
                var type = random.Next(enemyTypes.Length);
                User enemyUser = new User();
                enemyUser.Name = $"{enemyRace[race]} {enemyTypes[type]}";
                enemyUser.Level = level;
                enemyUser.Topscore = 0;
                Character enemy = new StartingCharacter(enemyUser, PickRandomWeapon(level));
                var inventory = ShopItemSpawner.GetARandomInventory(level);
                enemy = ItemDecoratorFactory.GetItems(inventory.Values.ToList(),enemy);
                enemies.Add(enemy);
                
            }
            return enemies;
        }
      
        private static IWeapon PickRandomWeapon(int level)
        {
            return WeaponFactory.GenerateRandomWeapon(level);
        }
    }
}
