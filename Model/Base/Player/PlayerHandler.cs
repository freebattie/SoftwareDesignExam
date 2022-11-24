


using Model.Base.Enums;
using Model.Base.Shop;
using Model.Base.Weapons;
using Model.Decorator.Abstract;
using Model.Decorator.Original;
using Model.Factory;


namespace Model.Base.Player
{

    /// <summary>
    /// handels all player logic
    /// </summary>
    public class PlayerHandler
    {
        #region private fields
        private User? _userInfo;
        private int _money = 300;
        private CharacterInfo _original = new StartingCharacterInfo();
        private CharacterInfo _player = new StartingCharacterInfo();
        private CharacterInfo _target = new StartingCharacterInfo ();
        private List<ShopItem> _playerInvetory = new ();
        private Dictionary<GearSpot, ShopItem> _activeItems = new();
        #endregion

        #region Props
        public int Money { get => _money; set => _money = value; }
        #endregion

        #region constructor
        public PlayerHandler()
        {

            SetupPlayer();
            if (_original == null)
                _original = new StartingCharacterInfo();
        }
        #endregion

        #region public methods
        public void Attack()
        {
            if (_target != null) 
                _player?.Attack(_target);
        }

        public List<ShopItem> GetInventory()
        {
            if (_playerInvetory != null)
                return _playerInvetory;
            else
                return
                    new();
        }
      /// <summary>
      /// gets all items the player has been decorated with
      /// </summary>
      /// <returns></returns>
        public Dictionary<GearSpot, ShopItem> GetActiveItems() {

     
            return _activeItems;
        }
        /// <summary>
        /// gets the current deocrated playerInfo
        /// </summary>
        /// <returns></returns>
        public CharacterInfo? GetPlayer()
        {
            return _player;
        }
        /// <summary>
        /// sets the target to attak
        /// </summary>
        /// <param name="character"></param>
        public void SetTarget(CharacterInfo character)
        {
            _target = character;
            GetPlayer()?.GetWeapon().SetTarget(character);
        }
        /// <summary>
        /// sets user loaded from database
        /// </summary>
        /// <param name="user"></param>
        public void SetUser(User user)
        {
            _userInfo = user;
            
            _original.SetUser(user);
        }
        /// <summary>
        /// set a new item at given gearspot, throw away the old item
        /// </summary>
        /// <param name="spot"></param>
        /// <param name="item"></param>
        public void SetActiveGearItem(GearSpot spot, ShopItem item) {
            if (item != null) 
                AddGearToSpot(spot, item);
        }

        
        /// <summary>
        /// re decorate original playerinfo whit new items
        /// this allows us to swap decorated items 
        /// </summary>
        public void EquiptAllActiveItems()
        {
            if (_original != null) 
                _player = CharacterInfoDecoratorFactory.GetItems(GetActiveItems().Values.ToList(), _original);
            
        }
        /// <summary>
        /// setup the basic info for player
        /// </summary>
        public void SetupPlayer()
        {
            
            _userInfo = new();
            _userInfo.Name = "";
            _userInfo.Level = 1;
            _userInfo.Topscore = 0;
            _userInfo.CurrentScore = 0;
            _playerInvetory = new();
            _original = new StartingCharacterInfo(_userInfo, new NoWeapon());
            _player = _original;
            //EquiptAllActiveItems();
        }

        /// <summary>
        /// check if player has money
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public bool CanAffordIt(int money) {
            if (Money - money >= 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// gets the user to write it back to database
        /// </summary>
        /// <returns></returns>
        public User GetUser() {
            if (_userInfo != null) {
                SetTopScore();
                return _userInfo;
            }
            else
                return new User();
            
        }
        /// <summary>
        /// remove item from inventory
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(Shop.ShopItem item) {
            _playerInvetory?.Remove(item);
        }

        /// <summary>
        /// used to get string name of all items player has
        /// </summary>
        /// <returns></returns>
        public List<string> GetInventoryAsString() {
            List<string> items = new();
            foreach (var item in GetInventory()) {
                items.Add(item.Name);
            }
            return items;
        }

       /// <summary>
       /// check if game over
       /// </summary>
       /// <returns></returns>
        public bool PlayerIsAlive() {
            if (_player?.GetHealth() < 0)
                return false;
            else
                return true;
        }
        #endregion

        #region private methods
        /// <summary>
        /// helper function for setting the gear
        /// </summary>
        /// <param name="spot"></param>
        /// <param name="item"></param>
        private void AddGearToSpot(GearSpot spot, ShopItem item) {
            var items = GetActiveItems();
            if (items.ContainsKey(spot)) {
                items[spot] = item;
            }
            else {
                items.Add(spot, item);
            }
        }
        private void SetTopScore() {
            if (_userInfo?.CurrentScore > _userInfo?.Topscore) {
                _userInfo.Topscore = _userInfo.CurrentScore;
            }
        }
        #endregion

    }
}
