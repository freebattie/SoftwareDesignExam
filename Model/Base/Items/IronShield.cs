using Model.Abstract;
using Model.Decorator;


namespace Model.Base.ConcreateDecorators {
    public class IronShield : CharacterDecorator {
        public IronShield(Character original) : base(original) {
        }

        public override void RemoveHealth(double weaponDmg) {
            weaponDmg += 10;
            base.RemoveHealth(weaponDmg);
        }

        public override string GetDescription() {
            return base.GetDescription() + ", Iron Shield";
        }
    }
}