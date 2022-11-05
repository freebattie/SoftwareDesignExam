using Model.Abstract;
using Model.Base.Weapons;
using Model.Enums;
using Model.Factory;
using Model.Interface;
using Persistence.Db;


namespace Model.Base {
    public class PlayerHandler {

        private User userInfo;
        private Character original;
        private Character player;
        private Character target;
        private List<ShopItem> playerInvetory;
        Dictionary<GearSpot, Item> ActiveItems = new ();


        public PlayerHandler() {
            SetupPlayer();
        }
        public void Attack() {
            player.Attack(target);
        }

        public List<ShopItem> GetInventory() {
            return playerInvetory;
        }

        public Character GetPlayer() {
            EquiptAllItems();
            return player;
        }

        public void setTarget(Character character) {
            throw new NotImplementedException();
        }

        public void SetUser(User user) {
           this.userInfo = user;
            original.SetUser(user);
        }
        private void EquiptAllItems() {
            player = ItemDecoratorFactory.GetItems(playerInvetory, original);
        }

        public void SetupPlayer() {
            userInfo = new();
            userInfo.Name = "";
            userInfo.Level = 1;
            userInfo.Topscore = 0;
            userInfo.CurrentScore = 0;
            original = new StartingCharacter(userInfo, StartingWeapon());
        }

        private IWeapon StartingWeapon() {
           return new Axe();
        }
    }
}
