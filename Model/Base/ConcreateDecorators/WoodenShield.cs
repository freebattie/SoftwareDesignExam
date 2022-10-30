using Model.Abstract;
using Model.Decorator;

namespace Model.Base.ConcreateDecorators {
    internal class WoodenShield : CharacterDecorator
    {
        //TODO: HAM,PEPPERONI ETC
        public WoodenShield(Character original) : base(original)
        {
        }

        public override void RemoveHealth(double weaponDmg)
        {
            weaponDmg -= 1;
            base.RemoveHealth(weaponDmg);
        }
        public override string GetDescription() {
            return base.GetDescription() + ", Wooden Shield";
        }
    }
}