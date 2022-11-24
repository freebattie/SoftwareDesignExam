using Model.Decorator.Abstract;

namespace Model.Decorator.Item {
    /// <summary>
    /// Konkret dekorator
    /// </summary>
    public class NoItem : CharacterInfoDecorator
    {
        public NoItem(CharacterInfo original) : base(original)
        {


        }

        public override string GetDescription() {
            return "You have no items opsy missing db?";
        }
    }
}
