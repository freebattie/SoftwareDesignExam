
using Model.Base.ViewModel;

namespace Model.Interface {
    public interface IView {
        void Draw();
        void AddViewModel( ViewModel vm);
       
    }
}
