


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

        private User? userInfo;
        private CharacterInfo original = new StartingCharacteGear();
        private CharacterInfo player = new StartingCharacteGear();
        private CharacterInfo target = new StartingCharacteGear ();
        private List<ShopItem> playerInvetory = new ();
        private Dictionary<GearSpot, ShopItem> activeItems = new();
       

        public PlayerHandler()
        {

            SetupPlayer();
            if (original == null)
                original = new StartingCharacteGear();
        }
        public void Attack()
        {
            if (target != null) 
                player?.Attack(target);
        }

        public List<ShopItem> GetInventory()
        {
            if (playerInvetory != null)
                return playerInvetory;
            else
                return
                    new();
        }
      
        public Dictionary<GearSpot, ShopItem> GetActiveItems() {

     
            return activeItems;
        }
        public CharacterInfo? GetPlayer()
        {
            return player;
        }

        public void setTarget(CharacterInfo character)
        {
            target = character;
        }

        public void SetUser(User user)
        {
            userInfo = user;
            
            original.SetUser(user);
        }
        public void SetActiveGearItem(GearSpot spot, ShopItem item) {
            if (item != null) 
                AddGearToSpot(spot, item);
        }

        private void AddGearToSpot(GearSpot spot, ShopItem item) {
            var items = GetActiveItems();
            if (items.ContainsKey(spot)) {
                items[spot] = item;
            }
            else {
                items.Add(spot, item);
            }
        }

        public void EquiptAllActiveItems()
        {
            if (original != null) 
                player = ItemDecoratorFactory.GetItems(GetActiveItems().Values.ToList(), original);
            
        }

        public void SetupPlayer()
        {
            
            userInfo = new();
            userInfo.Name = "";
            userInfo.Level = 1;
            userInfo.Topscore = 0;
            userInfo.CurrentScore = 0;
            playerInvetory = ShopItemSpawner.GetRandomListOfItems(4);
            original = new StartingCharacteGear(userInfo, StartingWeapon());
            player = original;
            EquiptAllActiveItems();
        }
        //TODO:fix
        private Weapon StartingWeapon()
        {
            return WeaponFactory.GenerateRandomWeapon(1);
        }

        public User GetUser() {
            if (userInfo != null) {
                SetTopScore();
                return userInfo;
            }
            else
                return new User();
            
        }

        private void SetTopScore() {
            if (userInfo?.CurrentScore > userInfo?.Topscore) {
                userInfo.Topscore = userInfo.CurrentScore;
            }
        }

        public void removeItem(ShopItem item) {
            playerInvetory?.Remove(item);
        }

        public List<string> GetInventoryAsString() {
            List<string> items = new();
            foreach (var item in GetInventory()) {
                items.Add(item.Name);
            }
            return items;
        }

       
        public bool PlayerIsAlive() {
            if (player?.GetHealth() < 0)
                return false;
            else
                return true;
        }
        
    }
}
