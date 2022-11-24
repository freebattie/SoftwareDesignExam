
using Model.Base.Player;
using Model.Base.Shop;
using Model.Base.Weapons.Abstract;
using Model.Decorator.Abstract;

namespace Model.Base.ViewModel
{
/// <summary>
/// used as a binder between game class and the views, allowing us to only need to update one instance og viewmodel in the game class
/// and then the views gets the updateted status form getters and props
/// </summary>
    public class ViewModel {

        #region private fileds
        private int _room;
        private PlayerHandler _playerhandler;
        List<Weapon> _weapons;
        List<ShopItem> _items;
        List<CharacterInfo> _enemies;
        List<User> _users;
        #endregion

        #region props
        public int Room { get => _room; set => _room = value; }
        public PlayerHandler Playerhandler { get => _playerhandler; set => _playerhandler = value; }
        public List<Weapon> Weapons { get => _weapons; set => _weapons = value; }
        public List<CharacterInfo> Enemies { get => _enemies; set => _enemies = value; }
        public List<ShopItem> Items { get => _items; set => _items = value; }
        public List<User> Users { get => _users; set => _users = value; }
        #endregion

        #region constroctors
        public ViewModel(int room, PlayerHandler playerhandler, List<Weapon> weapons, List<ShopItem> items, List<CharacterInfo> enemies, List<User> users) {
            this._room = room;
            this._playerhandler = playerhandler;
            this._weapons = weapons;
            this._items = items;
            this._enemies = enemies;
            this._users = users;
        }
        public ViewModel() {
            this._room = 1;
            this._playerhandler = new ();
            this._weapons = new();
            this._items = new();
            this._enemies = new();
            this._users = new();
        }
        #endregion


    }
}
