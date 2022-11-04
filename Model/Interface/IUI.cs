using Model.Abstract;
using Model.Enums;

//TODO:move user
using Persistence.Db;

namespace Model.Interface {
    public interface IUI {
        void Draw(Menu menu);
        string ReadIntInput<T>(List<T> list);
        void SetActiveModels(User user, Character player, List<Character> enimies);
        string HandelPlayerInput(Menu menu);
    }
}
