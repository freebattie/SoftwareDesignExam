﻿using Model.Decorator.Abstract;

namespace Model.Decorator.Items {
    internal class WoodenShield : CharacterDecorator
    {
        bool isbroken = false;
        double hitpoints = 4;
        double dmgReduction = 1;
        public WoodenShield(Character original) : base(original)
        {
        }

        public override void RemoveHealth(double weaponDmg)
        {
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
            return base.GetDescription() + "\n# Wooden Shield: "+(isbroken ? "is broken": $"has {hitpoints} left");
        }
    }
}