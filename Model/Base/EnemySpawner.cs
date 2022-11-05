using Model.Abstract;
using Model.Base.Weapons;
using Model.Factory;
using Model.Interface;
using Persistence.Db;

namespace Model.Base {
    public  class EnemySpawner {
        private readonly int level;
        private readonly int nrOfEnemies;
        private readonly List<string> allItems;
        private string[] enemyTypes = { "ManBear" ,"Orc","Knight","Worrior","RockMonster","Wampire",};
        public EnemySpawner(int nrOfEnemies,int level) {
            this.level = level;
            this.nrOfEnemies = nrOfEnemies;
            this.allItems = ItemDecoratorFactory.GetNameOFAllItemsInGame();
            Random random = new Random();
            for (int i = 0; i < level; i++) {
                var index = random.Next(allItems.Count);
                  
            }
            User enemyUser = new User();
            enemyUser.Name = "orc";
            enemyUser.Level = 1;
            enemyUser.Topscore = 0;
            Character orc = new StartingCharacter(enemyUser, PickRandomWeapon(level));


            orc = ItemDecoratorFactory.GetItems(playerInvetory.Values.ToList(), orc);
            Character orc2 = new StartingCharacter(enemyUser, PickRandomWeapon(level));


            orc2 = ItemDecoratorFactory.GetItems(playerInvetory.Values.ToList(), orc2);
        }
        public List<Character> SpawnEnemies() {
            List<Character> enemies = new List<Character>();
            Random random = new();
            for (int i = 0; i < nrOfEnemies; i++) {


                var nameIndex = random.Next(enemyTypes.Length);
                var enemyType = enemyTypes[nameIndex];
                var
            }

            return enemies;
        }
        private IWeapon PickRandomWeapon(int level) {
            return WeaponFactory.GenerateRandomWeapon(level);
        }
    }
}
