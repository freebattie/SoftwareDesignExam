using Model.Abstract;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Decorator {
    //TODO: HAM,PEPPERONI ETC
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

        public override void Attack(Character person) {
            int level = (int)GetLevel();
            if (!isUsed) {
                SetLevel(1000);
                isUsed = true;
                ActiveItems.Remove(GearSpot.TRINCKET);
            }
            base.Attack(person);
            
            SetLevel(level);
            Console.WriteLine(GetLevel());
            
        }
    }
}
