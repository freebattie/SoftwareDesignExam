using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Decorator {
    internal class ItemDecorator : Item {
        private Item _item;

        public ItemDecorator(Item item) {
            _item = item;
        }

        public override double GetDamage() {
            return _item.GetDamage();
        }

        public override string GetDescription() {
            return _item.GetDescription();  
        }

        public override double GetHealth() {
            return _item.GetHealth();
        }
    }
}
