using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Decorator {
    public class CharacterDecorator : Character {
        private readonly Character original;

        public CharacterDecorator(Character original) {
            this.original = original;
        }
        public override void AddCrit() {
            original.AddCrit();
        }

        public override void AddLevel() {
            original.AddLevel();
        }

        public override void Attack(Character person) {
            original.Attack(person);
        }

        public override double GetHealth() {
            return original.GetHealth();
        }

        public override void IncreaseHealth(double health) {
            original.IncreaseHealth(health);
        }

        public override void RemoveHealth(double weaponDmg) {
            original.RemoveHealth(weaponDmg);
        }
    }
}
