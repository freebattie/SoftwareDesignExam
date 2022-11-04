

using Model.Abstract;
using Model.Enums;
using Model.Interface;
using Presentation.Utils;
using Presentation.Views;
using System.Collections.Generic;
using Persistence.Db;

namespace Presentation {
    public class UI: IUI {
        Dictionary<Menu,IView> _allMenuViews;
        public UI(Character player, List<Character> enemies) {
            User dummyPlayer = new();
            dummyPlayer.Name = "Sigmund";
            dummyPlayer.Level = 12;
            _allMenuViews = new Dictionary<Menu,IView>();
            _allMenuViews.Add(Menu.ATTACK, new AttackMenuView(player,enemies));
            _allMenuViews.Add(Menu.LOGIN, new LoginMenuView());
            _allMenuViews.Add(Menu.GAMEOVER, new GameOverView(dummyPlayer));
            _allMenuViews.Add(Menu.MAINMENU, new MainMenuView(dummyPlayer));
            
        }
        public void Draw(Menu menu) {
            _allMenuViews[menu].Draw();
        }

        public string ReadIntInput<T>(List<T> list) {
           return Reader.ReadInt(list);
        }

        public string ReadIntInput() {
            return Reader.ReadInt();
        }

        public string ReadStringInput() {
            return Reader.ReadString();
        }

        public void SetPlayer(Character player,List<Character> enemies) {
            _allMenuViews[Menu.ATTACK]= new AttackMenuView(player, enemies);
        }
    }
}
