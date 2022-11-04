

using Model.Abstract;
using Model.Enums;
using Model.Interface;
using Persistence.Db;
using Presentation.Utils;
using Presentation.Views;
using System.Collections.Generic;
using Persistence.Db;

namespace Presentation {
    public class UI: IUI {
        Dictionary<Menu,IView> _allMenuViews;
        public UI(Character player, List<Character> enemies) {
            _allMenuViews = new Dictionary<Menu,IView>();
            _allMenuViews.Add(Menu.ATTACK, new AttackMenuView(player,enemies));
            _allMenuViews.Add(Menu.LOGIN, new LoginMenuView());
             User dummyPlayer = new();
             dummyPlayer.Name = "Sigmund";
             dummyPlayer.Level = 12;
            _allMenuViews.Add(Menu.GAMEOVER, new GameOverView(dummyPlayer));
        }
        public void Draw(Menu menu) {
            _allMenuViews[menu].Draw();
        }

        public string HandelPlayerInput(Menu menu) {
            string value = "";
            switch (menu) {
                case Menu.ATTACK: {
                        value = Reader.ReadIntAsString();

                        break;
                    }
                case Menu.LOGIN: {
                        value = Reader.ReadString();
                        break;
                    }

            }
            return null;
        }

        public string ReadIntInput<T>(List<T> list) {
           return Reader.ReadIntAsString(list);
        }

        public void SetActiveModels(User user, Character player, List<Character> enimies) {
            throw new NotImplementedException();
        }

        public void SetPlayer(Character player,List<Character> enemies) {
            _allMenuViews[Menu.ATTACK]= new AttackMenuView(player, enemies);
        }

        
    }
}
