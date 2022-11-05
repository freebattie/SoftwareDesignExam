using Model.Base.Enums;
using Model.Base.Player;
using Model.Decorator.Abstract;

namespace Model.Interface
{
    public interface IUI {
        void Draw(Menu menu);
        string ReadIntInput<T>(List<T> list);
        void SetActiveModels(PlayerHandler player, List<Character> enimies);
        string HandelPlayerInput(Menu menu);
    }
}
