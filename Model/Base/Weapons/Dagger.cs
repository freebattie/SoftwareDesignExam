using Model.Base.Weapons.Abstract;
using Model.Decorator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Base.Weapons {
    internal class Dagger : Weapon {
        private CharacterInfo? _target;
        public Dagger() : base() {
           
            Description = "does 3x damage if enemy healt is below 25%";
        }
        public override double GetDamage() {
            var life = _target?.GetHealth();
            var max = _target?.GetMaxHealth();
            if ((life / max) *100 <= 25) {
                return Damage * 3;
            }
            else
                return Damage;
        }

        public override void SetTarget(CharacterInfo target) {
            _target = target;
        }
    }
}
