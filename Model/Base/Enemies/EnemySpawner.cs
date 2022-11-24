

using Model.Base.Player;
using Model.Base.Shop;
using Model.Base.Weapons.Abstract;
using Model.Decorator.Abstract;
using Model.Decorator.Original;
using Model.Factory;


namespace Model.Base.Enemies
{
    public class EnemySpawner
    {
        
        
        private static string[] enemyRace = { "Orc", "Elf", "Giant", "Wearvolf", "RockMonster", "Wampire", };
        private static string[] enemyTypes = { "Shaman", "Priest", "Knight", "Worrior", "King", "Commander", };
        

        public static List<CharacterInfo> SpawnEnemies(int nrOfEnemies, int level)
        {
            List<CharacterInfo> enemies = new ();
           
             
            var allItems = CharacterInfoDecoratorFactory.GetNameOFAllItemsInGame();
           
            for (int i = 0; i < nrOfEnemies; i++)
            {
                Random random = new Random();
                var race = random.Next(enemyTypes.Length);
                var type = random.Next(enemyTypes.Length);
                User enemyUser = new User();
                enemyUser.Name = $"{enemyRace[race]} {enemyTypes[type]}";
                enemyUser.Level = level;
                enemyUser.Topscore = 0;
                CharacterInfo enemy = new StartingCharacterInfo(enemyUser, PickRandomWeapon(level));
                var inventory = ShopItemSpawner.GetRandomActiveItems(level);
                enemy = CharacterInfoDecoratorFactory.GetItems(inventory.Values.ToList(),enemy);
                enemies.Add(enemy);
                
            }
            return enemies;
        }
      
        private static Weapon PickRandomWeapon(int level)
        {
            return WeaponFactory.GenerateRandomWeapon(level);
        }
        private static List<Weapon> GetRandomWeaponList(int level,int weapons) {
            List<Weapon> weaponsList = new List<Weapon>();
            for (int i = 0; i < weapons; i++) {
                Weapon weapon = WeaponFactory.GenerateRandomWeapon(level);
                weaponsList.Add(weapon);
            }
            return weaponsList;
            
        }
    }
}
