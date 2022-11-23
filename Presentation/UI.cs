

using Model.Base.Enums;
using Model.Base.Player;
using Model.Decorator.Abstract;
using Model.Interface;
using Presentation.Utils;
using Presentation.Views;
using Presentation.Views.rooms;
using Presentation.Views.ShopView;

namespace Presentation {
    public class UI: IUI {
        private Dictionary<Menu,IView> _allMenuViews;

        public UI() {

            _allMenuViews = new Dictionary<Menu, IView> {
                { Menu.ATTACK, new AttackMenuView(new PlayerHandler(), new List<CharacterInfo>(), 0) },
                { Menu.LOGIN, new LoginMenuView() },
                { Menu.GAMEOVER, new GameOverView() },
                { Menu.MAINMENU, new MainMenuView() },
                { Menu.ERROR, new ErrorView() },
                { Menu.INVETORY, new InventoryView() },
                { Menu.ENEMYTURN, new EnemyTurnView() },
                { Menu.HIGHSCORE, new HighScoreView() },
                { Menu.SHOP, new ShopMainMenuView() },
                { Menu.WEAPONSHOP, new ShopWeaponView() },
                { Menu.ITEMSHOP, new ShopItemView() }
            };
            _allMenuViews[Menu.NEXTROOM] = new RoomDoneView(); 

        }

        public void Draw(Menu menu) {
            _allMenuViews[menu].Draw();
        }

        public string HandelPlayerInput(Menu menu) {


            if (menu == Menu.LOGIN )
                return Reader.ReadString();
            else if (menu == Menu.ENEMYTURN || menu == Menu.HIGHSCORE)
                return Reader.KeyPressed();
            else
                return Reader.ReadIntAsString();
            
        }

        public void SetActiveModels(
            PlayerHandler playerhandler,
            List<CharacterInfo> enemies,
            List<User> users,
            int room) {
           
            _allMenuViews[Menu.ATTACK] = new AttackMenuView(playerhandler, enemies, room);
            _allMenuViews[Menu.LOGIN] = new LoginMenuView(users);
            _allMenuViews[Menu.GAMEOVER] = new GameOverView(playerhandler);
            _allMenuViews[Menu.MAINMENU] = new MainMenuView();
            _allMenuViews[Menu.ERROR] = new ErrorView();
            _allMenuViews[Menu.INVETORY] = new InventoryView(playerhandler);
            _allMenuViews[Menu.ENEMYTURN] = new EnemyTurnView(playerhandler, enemies);
            _allMenuViews[Menu.HIGHSCORE] = new HighScoreView(users);
            _allMenuViews[Menu.NEXTROOM] = new RoomDoneView(playerhandler,room);
        }

       

        
    }
}
