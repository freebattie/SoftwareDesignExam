using Model.Decorator.Abstract;

namespace Model.Decorator.Items {
    //TODO: HAM,PEPPERONI ETC
    public class NoItem : CharacterGearDecorator
    {
        public NoItem(CharacterInfo original) : base(original)
        {
        }
    }
}
