

using Model.Base.Enums;
using Model.Base.Player;
using Model.Decorator.Abstract;
using Model.Decorator.Original;
using Model.Interface;
using Presentation.Utils;
using Presentation.Views;

namespace Presentation {
    public class UI: IUI {
        private Dictionary<Menu,IView> _allMenuViews;
        private List<User> _users;

        public UI() {

            _allMenuViews = new Dictionary<Menu, IView>();
            _allMenuViews.Add(Menu.ATTACK, new AttackMenuView(new PlayerHandler(),new List<CharacterInfo>(),0));
            _allMenuViews.Add(Menu.LOGIN, new LoginMenuView());
            _allMenuViews.Add(Menu.GAMEOVER, new GameOverView());
            _allMenuViews.Add(Menu.MAINMENU, new MainMenuView());
            _allMenuViews.Add(Menu.ERROR, new ErrorView());
            _allMenuViews.Add(Menu.INVETORY, new InventoryView());
            _allMenuViews.Add(Menu.ENEMYTURN, new EnemyTurnView());
            _allMenuViews.Add(Menu.HIGHSCORE, new HighScoreView());
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

        public string ReadIntInput<T>(List<T> list) {
           return Reader.ReadIntAsString(list);
        }

        public void SetActiveModels(
            PlayerHandler playerhandler,
            List<CharacterInfo> enemies,
            List<User> users,
            int room) {
           
            _allMenuViews[Menu.ATTACK] = new AttackMenuView(playerhandler, enemies, room);
            _allMenuViews[Menu.LOGIN] = new LoginMenuView(users);
            _allMenuViews[Menu.GAMEOVER] = new GameOverView(playerhandler.GetUser());
            _allMenuViews[Menu.MAINMENU] = new MainMenuView();
            _allMenuViews[Menu.ERROR] = new ErrorView();
            _allMenuViews[Menu.INVETORY] = new InventoryView(playerhandler.GetInventory(),playerhandler.GetActiveItems());
            _allMenuViews[Menu.ENEMYTURN] = new EnemyTurnView(playerhandler, enemies);
            _allMenuViews[Menu.HIGHSCORE] = new HighScoreView(users);
            _allMenuViews[Menu.NEXTROOM] = new RoomDoneView(playerhandler,room);
        }

       

        
    }
}
