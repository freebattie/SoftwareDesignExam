


using Model.Decorator.Abstract;

namespace Model.Decorator.Item {
    public class IronShield : CharacterInfoDecorator {

        bool isbroken = false;
        double hitpoints = 100;
        double dmgReduction = 25;
        public IronShield(CharacterInfo original) : base(original) {
        }

        public override void RemoveHealth(double weaponDmg) {
            if (hitpoints < 1)
                isbroken = true;

            if (!isbroken) {
                weaponDmg -= weaponDmg >= dmgReduction ? dmgReduction : weaponDmg;
                hitpoints -= hitpoints;
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
