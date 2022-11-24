using Model.Decorator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Decorator.Item {
    internal class Horse : CharacterInfoDecorator {
        public Horse(CharacterInfo original) : base(original) {
        }

         public override string GetDescription() {
            return base.GetDescription() + "\n# War Horse: You ride it " ;
        }
    }
}
