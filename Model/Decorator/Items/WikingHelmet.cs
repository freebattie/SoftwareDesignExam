

using Model.Decorator.Abstract;

namespace Model.Decorator.Items {
    public class WikingHelmet:CharacterDecorator {
        bool isbroken = false;
        double hitpoints = 22;
        double dmgReduction = 15;
        public WikingHelmet(Character original) : base(original) {
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
            return base.GetDescription() + "\n# Wiking helmet: " + (isbroken ? "is broken" : $"has {hitpoints} hitpoints left");
        }
    }
}

