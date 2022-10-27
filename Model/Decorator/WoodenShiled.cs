﻿using Model.Abstract;

namespace Model.Decorator
{
    internal class WoodenShiled : CharacterDecorator {
        public WoodenShiled(Character original) : base(original) {
        }

        public override void RemoveHealth(double weaponDmg) {
            weaponDmg -= 1;
            base.RemoveHealth(weaponDmg);
        }
    }
}