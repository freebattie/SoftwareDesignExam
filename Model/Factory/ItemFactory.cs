using Model.Abstract;
using Model.Decorator.ConcreateDecrators;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Factory {
    internal class ItemFactory {

        public static Item GetDecoratorItem(List<GearItems> items,Item gear) {
            foreach (var item in items) {
                switch (item) {
                    case GearItems.HELMET: {
                            gear = new WikingHelmet(gear);
                            break;
                        }
                    case GearItems.SHIELD: {
                            gear = new WikingShield(gear);
                            break;
                        }
                   default: return null;
                    
                }
            }
            return gear;
        }
    }
}
