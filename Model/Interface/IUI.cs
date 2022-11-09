using Model.Base.Enums;
using Model.Base.Player;
using Model.Decorator.Abstract;

namespace Model.Interface
{
    public interface IUI {
        void Draw(Menu menu);
        
        string HandelPlayerInput(Menu menu);
        void SetActiveModels(PlayerHandler playerHandler, List<CharacterInfo> enemyList, List<User> users, int roomNr);
    }
}
