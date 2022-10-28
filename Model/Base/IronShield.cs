using Model.Abstract;
using Model.Decorator;
using Model.Factory;

namespace Model.Base
{
    internal class IronShield : CharacterDecorator {
        public IronShield(Character original) : base(original) {
        }

        public override void RemoveHealth(double weaponDmg) {
            weaponDmg += 10;
            base.RemoveHealth(weaponDmg);
        }
    }
}