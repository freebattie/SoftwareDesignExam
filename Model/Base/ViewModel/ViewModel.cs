using Model.Base;
using Model.Base.Enums;
using Model.Base.Player;
using Model.Base.Shop;
using Model.Decorator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopItem = Model.Base.Shop.ShopItem;

namespace Presentation.ViewModel {
    public class ViewModel {
        private int room;
        private PlayerHandler playerhandler;
        List<Weapon> weapons;
        List<ShopItem> Items;
        List<CharacterInfo> enemies;
        List<User> users;

        public ViewModel(int room, PlayerHandler playerhandler, List<Weapon> weapons, List<ShopItem> items, List<CharacterInfo> enemies, List<User> users) {
            this.room = room;
            this.playerhandler = playerhandler;
            this.weapons = weapons;
            Items = items;
            this.enemies = enemies;
            this.users = users;
        }

        public int Room { get => room; set => room = value; }
        public PlayerHandler Playerhandler { get => playerhandler; set => playerhandler = value; }
        public List<Weapon> Weapons { get => weapons; set => weapons = value; }
        public List<CharacterInfo> Enemies { get => enemies; set => enemies = value; }
        public List<ShopItem> Items1 { get => Items; set => Items = value; }
        public List<User> Users { get => users; set => users = value; }
    }
}
