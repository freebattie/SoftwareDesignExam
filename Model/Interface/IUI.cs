using Model.Base.Enums;
using Model.Base.Player;
using Model.Decorator.Abstract;

namespace Model.Interface
{
    public interface IUI {
        void Draw(Menu menu);
        string ReadIntInput<T>(List<T> list);
        string HandelPlayerInput(Menu menu);
        void SetActiveModels(PlayerHandler playerHandler, List<Character> enemyList, List<User> users, int roomNr);
    }
}
