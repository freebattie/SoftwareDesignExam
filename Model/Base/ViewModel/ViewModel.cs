
using Model.Base.Player;
using Model.Base.Shop;
using Model.Base.Weapons.Abstract;
using Model.Decorator.Abstract;

namespace Model.Base.ViewModel
{
    public class ViewModel {
        private int room;
        private PlayerHandler playerhandler;
        List<Weapon> weapons;
        List<ShopItem> items;
        List<CharacterInfo> enemies;
        List<User> users;

        public ViewModel(int room, PlayerHandler playerhandler, List<Weapon> weapons, List<ShopItem> items, List<CharacterInfo> enemies, List<User> users) {
            this.room = room;
            this.playerhandler = playerhandler;
            this.weapons = weapons;
            this.items = items;
            this.enemies = enemies;
            this.users = users;
        }
        public ViewModel() {
            this.room = 1;
            this.playerhandler = new ();
            this.weapons = new();
            this.items = new();
            this.enemies = new();
            this.users = new();
        }

        public int Room { get => room; set => room = value; }
        public PlayerHandler Playerhandler { get => playerhandler; set => playerhandler = value; }
        public List<Weapon> Weapons { get => weapons; set => weapons = value; }
        public List<CharacterInfo> Enemies { get => enemies; set => enemies = value; }
        public List<ShopItem> Items { get => items; set => items = value; }
        public List<User> Users { get => users; set => users = value; }
    }
}
