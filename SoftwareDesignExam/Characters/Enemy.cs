﻿using test.Base;

namespace test.Characters
{
    internal class Enemy : Character
    {
        public override void DoDamage(Character person)
        {
            float dmg = Weapon.Damage;
            person.Health -= dmg;
        }

        public override double GetMaxCritChance() {
            throw new NotImplementedException();
        }

        public override double GetUsersHealth() {
            throw new NotImplementedException();
        }

        public override double GetUsersLevel() {
            throw new NotImplementedException();
        }

        public override void RemoveHealth(double dmg) {
            Health -= dmg;
        }
    }
}