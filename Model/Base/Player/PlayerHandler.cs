


using Model.Base.Enums;
using Model.Base.Shop;
using Model.Base.Weapons;
using Model.Decorator.Abstract;
using Model.Decorator.Original;
using Model.Factory;


namespace Model.Base.Player
{
    public class PlayerHandler
    {

        private User? userInfo;
        private int money = 300;
        private CharacterInfo original = new StartingCharacterInfo();
        private CharacterInfo player = new StartingCharacterInfo();
        private CharacterInfo target = new StartingCharacterInfo ();
        private List<ShopItem> playerInvetory = new ();
        private Dictionary<GearSpot, ShopItem> activeItems = new();

        public int Money { get => money; set => money = value; }

        public PlayerHandler()
        {

            SetupPlayer();
            if (original == null)
                original = new StartingCharacterInfo();
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
                player = CharacterInfoDecoratorFactory.GetItems(GetActiveItems().Values.ToList(), original);
            
        }

        public void SetupPlayer()
        {
            
            userInfo = new();
            userInfo.Name = "";
            userInfo.Level = 1;
            userInfo.Topscore = 0;
            userInfo.CurrentScore = 0;
            playerInvetory = new();
            original = new StartingCharacterInfo(userInfo, new NoWeapon());
            player = original;
            //EquiptAllActiveItems();
        }
        public bool CanAffordIt(int money) {
            if (Money - money >= 0)
                return true;
            else
                return false;
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

        public void removeItem(Shop.ShopItem item) {
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
