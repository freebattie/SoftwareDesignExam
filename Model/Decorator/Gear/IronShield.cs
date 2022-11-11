


using Model.Decorator.Abstract;

namespace Model.Decorator.Gear {
    public class IronShield : CharacterInfoDecorator {

        bool isbroken = false;
        double hitpoints = 10;
        double dmgReduction = 5;
        public IronShield(CharacterInfo original) : base(original) {
        }

        public override void RemoveHealth(double weaponDmg) {
            if (hitpoints < 1)
                isbroken = true;

            if (!isbroken) {
                weaponDmg -= weaponDmg >= dmgReduction ? dmgReduction : weaponDmg;
                hitpoints -= weaponDmg >= dmgReduction ? hitpoints : weaponDmg;
                base.RemoveHealth(weaponDmg);
            }
            else
                base.RemoveHealth(weaponDmg);
        }
        public override string GetDescription() {
            return base.GetDescription() + "\n# Iron Shield: " + (isbroken ? "is broken" : $"has {hitpoints} left");
        }
    }
}
