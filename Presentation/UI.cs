

using Model.Base.Enums;
using Model.Base.Player;
using Model.Base.ViewModel;
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
                { Menu.ATTACK, new AttackMenuView() },
                { Menu.LOGIN, new LoginMenuView() },
                { Menu.GAMEOVER, new GameOverView() },
                { Menu.MAINMENU, new MainMenuView() },
                { Menu.ERROR, new ErrorView() },
                { Menu.INVETORY, new InventoryView() },
                { Menu.ENEMYTURN, new EnemyTurnView() },
                { Menu.HIGHSCORE, new HighScoreView() },
                { Menu.SHOP, new ShopMainMenuView() },
                { Menu.WEAPONSHOP, new ShopWeaponView() },
                { Menu.ITEMSHOP, new ShopItemView() },
                { Menu.NOMONEY, new NoMoneyView() },
                { Menu.NEXTROOM,new RoomDoneView() },
                 { Menu.DOWNLOAD,new DownloadView() }
            };
            

        }

        public void Draw(Menu menu) {
            _allMenuViews[menu].Draw();
        }

        public string HandelPlayerInput(Menu menu) {


            if (menu == Menu.LOGIN )
                return Reader.ReadString();
            else if (menu == Menu.ENEMYTURN || menu == Menu.HIGHSCORE || menu == Menu.NOMONEY)
                return Reader.KeyPressed();
            else
                return Reader.ReadIntAsString();
            
        }

        public void SetActiveViewModel(ViewModel vm) {
           foreach(Menu menu in Enum.GetValues(typeof(Menu))) {
                _allMenuViews[menu].AddViewModel(vm); 
            }
          
        }

       

        
    }
}
