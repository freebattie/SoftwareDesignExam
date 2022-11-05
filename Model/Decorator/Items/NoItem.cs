using Model.Decorator.Abstract;

namespace Model.Decorator.Items {
    //TODO: HAM,PEPPERONI ETC
    public class NoItem : CharacterDecorator
    {
        public NoItem(Character original) : base(original)
        {
        }
    }
}
