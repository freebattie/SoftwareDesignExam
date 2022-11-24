

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
        #region private static fields 
        private static string[] _enemyRace = { "Orc", "Elf", "Giant", "Wearvolf", "RockMonster", "Wampire", };
        private static string[] _enemyTypes = { "Shaman", "Priest", "Knight", "Worrior", "King", "Commander", };
        #endregion

        #region public static methods
        /// <summary>
        /// used to spawn a random set of enemies based on given nr of enemies and  level
        /// </summary>
        /// <param name="nrOfEnemies"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static List<CharacterInfo> SpawnEnemies(int nrOfEnemies, int level)
        {
            List<CharacterInfo> enemies = new ();
           
             
            var allItems = CharacterInfoDecoratorFactory.GetNameOFAllItemsInGame();
           
            for (int i = 0; i < nrOfEnemies; i++)
            {
                Random random = new Random();
                var race = random.Next(_enemyTypes.Length);
                var type = random.Next(_enemyTypes.Length);
                User enemyUser = new User();
                enemyUser.Name = $"{_enemyRace[race]} {_enemyTypes[type]}";
                enemyUser.Level = level;
                enemyUser.Topscore = 0;
                CharacterInfo enemy = new StartingCharacterInfo(enemyUser, PickRandomWeapon(level));
                var inventory = ShopItemSpawner.GetRandomActiveItems(level);
                enemy = CharacterInfoDecoratorFactory.GetItems(inventory.Values.ToList(),enemy);
                enemies.Add(enemy);
                
            }
            return enemies;
        }
        #endregion

        #region private static methods

        /// <summary>
        /// Gives the enemy a random weapon based on level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private static Weapon PickRandomWeapon(int level)
        {
            return WeaponFactory.GenerateRandomWeapon(level);
        }
        #endregion
    }
}
