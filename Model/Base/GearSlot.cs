using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Abstract;

namespace Model.Base
{
    public class GearSlot : Item
    {
       public GearSlot() {
            Name = "Player has: ";
        }
        public override double GetDamage()
        {
            return Damage;
        }

        public override string GetDescription()
        {
            return Name;
        }

        public override double GetHealth()
        {
            return Health;
        }
    }
}
