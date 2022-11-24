using Model.Base.Enums;
using Model.Base.Player;
using Model.Base.ViewModel;
using Model.Decorator.Abstract;

namespace Model.Interface
{
    public interface IUI {
        void Draw(Menu menu);
        
        string HandelPlayerInput(Menu menu);
        void SetActiveViewModel(ViewModel vm);
    }
}
