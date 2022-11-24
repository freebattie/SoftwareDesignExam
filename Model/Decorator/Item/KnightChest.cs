using Model.Decorator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Decorator.Item {
    internal class KnightChest: CharacterInfoDecorator {
        
        public KnightChest(CharacterInfo original) : base(original) {
            IncreaseHealth(200);
            AddCrit();

        }
        public override string GetDescription() {
            return base.GetDescription() + "\n# Knights Chest: increases your Health by 100 " ;
        }

        public override void AddCrit() {
            base.AddCrit();
            base.AddCrit();
            base.AddCrit();
            base.AddCrit();

        }

        public override double GetHealth() {
            return base.GetHealth()+100;

        }
       

        public override void IncreaseHealth(double health) {
            base.IncreaseHealth(health);
        }
    }
}
