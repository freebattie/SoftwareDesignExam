using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Decorator {
    public class RabbitsFoot : CharacterDecorator {
        private bool isUsed = false;
        public RabbitsFoot(Character original) : base(original) {

        }
        public override void RemoveHealth(double weaponDmg) {
            if (GetHealth() - weaponDmg <= 0 && !isUsed) {
                weaponDmg = 0;
                isUsed = true;
            }
            base.RemoveHealth(weaponDmg);
        }
    }
}
