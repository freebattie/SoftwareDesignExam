using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Abstract {
    public abstract class Item {
        public string Name { get; set; }
        public double Damage { get; set; }
        public double Health { get; set; }
        public double Crit { get; set; }



        public abstract double GetDamage();
        public abstract string GetDescription();
        public abstract double GetHealth();
       
    }
}
