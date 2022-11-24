using Model.Decorator.Abstract;

namespace Model.Decorator.Item {
    /// <summary>
    /// Konkret dekorator
    /// </summary>
    internal class WoodenShield : CharacterInfoDecorator
    {
        bool isbroken = false;
        double hitpoints = 4;
        double dmgReduction = 1;
        public WoodenShield(CharacterInfo original) : base(original)
        {
        }

        public override void RemoveHealth(double weaponDmg)
        {
            if (hitpoints < 1)
                isbroken = true;

            if (!isbroken) {
                weaponDmg -= weaponDmg >= dmgReduction ? dmgReduction : weaponDmg;
                hitpoints -= weaponDmg < dmgReduction ? weaponDmg : dmgReduction;
                base.RemoveHealth(weaponDmg);
            }
            else
                base.RemoveHealth(weaponDmg);
        }
        public override string GetDescription() {
            return base.GetDescription() + "\n# Wooden Shield: "+(isbroken ? "is broken": $"has {hitpoints} left");
        }
    }
}