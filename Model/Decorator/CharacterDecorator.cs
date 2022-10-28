using Model.Abstract;
using Model.Enums;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Decorator {

    //TODO: PizzaDecorator
    public class CharacterDecorator : Character {
        private readonly Character original;

        public CharacterDecorator(Character original) {
            this.original = original;
        }
        public override void AddCrit() {
            original.AddCrit();
        }
        public override void Attack(Character person) {
            original.Attack(person);
        }

        public override int GetDamageInRange(int min, int max) {
           return original.GetDamageInRange(min, max);
        }

        public override string GetDescription() {
            return original.GetDescription();
        }

        public override double GetHealth() {
            return original.GetHealth();
        }

        public override double GetLevel() {
            return original.GetLevel();
        }

        public override void IncreaseHealth(double health) {
            original.IncreaseHealth(health);
        }

        public override void RemoveHealth(double weaponDmg) {
            original.RemoveHealth(weaponDmg);
        }

        public override void SetLevel(int level) {
            original.SetLevel(level);
        }

        public override void SetWeapon(IWeapon weapon) {
           original.SetWeapon(weapon);
        }

        public override double CheckForCritDamage(double dmg) {
            return original.CheckForCritDamage(dmg);
        }

        public override void AddItemToInventory(GearSpot spot, Item item) {
            original.AddItemToInventory(spot,item);
        }

        public override void RemoveItemFromInventory(GearSpot item) {
            original.RemoveItemFromInventory(item);
        }

        public override void AddItemToActiveItems(GearSpot spot, Item item) {
           original.AddItemToActiveItems(spot,item);
        }

        public override void RemoveItemFromActiveItems(GearSpot item) {
            original.RemoveItemFromActiveItems(item);
        }

        public override List<Item> GetActiveItems() {
            return original.GetActiveItems();
        }

        public override Dictionary<GearSpot, Item> GetInventoryItems() {
            //TODO: Sjå på denne
           return original.GetInventoryItems();
        }

        public override void MoveFromInvetoryToActiveItem(GearSpot spot) {
            original.MoveFromInvetoryToActiveItem(spot);
        }

        public override Item GetInventoryItem(GearSpot spot) {
            return original.GetInventoryItem(spot);
        }
    }
}
