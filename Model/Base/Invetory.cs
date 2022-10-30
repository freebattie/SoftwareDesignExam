using Model.Abstract;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Model.Base {
    public class Invetory {
        private Dictionary<GearSpot,Item>? items;

        public Invetory(Dictionary<GearSpot,Item> items) {
            this.Items = items;
        }
        public Item GetItem(GearSpot spot) {
            return items[spot];
        }
        public void AddItem(GearSpot gearSpot, Item itemName) {
            items[gearSpot] = itemName;
        }
        public void RemoveItem(GearSpot spot) {
            items.Remove(spot);
        }
        public Dictionary<GearSpot,Item>? Items { get => items; set => items = value; }
    }
}
