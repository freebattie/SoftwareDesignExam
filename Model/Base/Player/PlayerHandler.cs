


using Model.Base.Enums;
using Model.Base.Shop;
using Model.Base.Weapons;
using Model.Decorator.Abstract;
using Model.Decorator.Original;
using Model.Factory;
using Model.Interface;

namespace Model.Base.Player
{
    public class PlayerHandler
    {

        private User userInfo;
        private Character original;
        private Character player;
        private Character target;
        private List<ShopItem> playerInvetory;
        private Dictionary<GearSpot, ShopItem> activeItems = new();
        private bool isDead;

        public PlayerHandler()
        {
            SetupPlayer();
        }
        public void Attack()
        {
           
            player.Attack(target);
        }

        public List<ShopItem> GetInventory()
        {
            return playerInvetory;
        }
      
        public Dictionary<GearSpot, ShopItem> GetActiveItems() {
            
            return activeItems;
        }
        public Character GetPlayer()
        {
           
            return player;
        }

        public void setTarget(Character character)
        {
            target = character;
        }

        public void SetUser(User user)
        {
            userInfo = user;
            
            original.SetUser(user);
        }
        public void SetActiveGearItem(GearSpot spot, ShopItem item) {

            if (activeItems.ContainsKey(spot)) {
                activeItems[spot] = item;
            }
            else {
                activeItems.Add(spot, item);
            }
        }
        public void EquiptAllActiveItems()
        {

            player = ItemDecoratorFactory.GetItems(activeItems.Values.ToList(), original);
            
        }

        public void SetupPlayer()
        {
            userInfo = new();
            userInfo.Name = "";
            userInfo.Level = 1;
            userInfo.Topscore = 0;
            userInfo.CurrentScore = 0;
            playerInvetory = ShopItemSpawner.GetRandomListOfItems(4);
            original = new StartingCharacter(userInfo, StartingWeapon());
            EquiptAllActiveItems();
        }
        //TODO:fix
        private Weapon StartingWeapon()
        {
            return WeaponFactory.GenerateRandomWeapon(1);
        }

        public User GetUser() {
            SetTopScore();
            return userInfo;
        }

        private void SetTopScore() {
            if (userInfo.CurrentScore > userInfo.Topscore) {
                userInfo.Topscore = userInfo.CurrentScore;
            }
        }

        public void removeItem(ShopItem item) {
            playerInvetory.Remove(item);
        }

        public List<string> GetInventoryAsString() {
            List<string> items = new();
            foreach (var item in playerInvetory) {
                items.Add(item.Name);
            }
            return items;
        }

       
        public bool PlayerIsAlive() {
            if (player.GetHealth() < 0)
                return false;
            else
                return true;
        }
        
    }
}
