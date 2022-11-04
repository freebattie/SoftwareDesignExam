

using Model.Abstract;
using Model.Enums;
using Model.Interface;
using Presentation.Utils;
using Presentation.Views;
using System.Collections.Generic;

namespace Presentation {
    public class UI: IUI {
        Dictionary<Menu,IView> _menu;

        
        public UI(Character player, List<Character> enemies) {
            _menu = new Dictionary<Menu,IView>();
            _menu.Add(Menu.ATTACK, new AttackMenuView(player,enemies));
            _menu.Add(Menu.LOGIN, new LoginMenuView());
            _menu.Add(Menu.ERROR, new ErrorView());
        }
        public void Draw(Menu menu) {
            _menu[menu].Draw();
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
            _menu[Menu.ATTACK]= new AttackMenuView(player, enemies);
        }
    }
}
