using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Decorator.ConcreateDecrators {
    internal partial class WikingHelmet : ItemDecorator {
        public WikingHelmet(Item item) : base(item) {
        }

        public override double GetDamage() {
            return base.GetDamage() +10;
        }

        public override string GetDescription() {
            return base.GetDescription() +", Wiking Helmet";
        }

        public override double GetHealth() {
            return base.GetHealth() + 25;
        }
    }
}
