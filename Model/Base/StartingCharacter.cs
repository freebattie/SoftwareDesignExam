
using Model.Abstract;
using Model.Enums;
using Model.Interface;

namespace Model.Base
{
    public class StartingCharacter : Character
    {
        private StartingCharacter() { }
        public StartingCharacter(string name,IWeapon weapon,Dictionary<GearSpot,Item> items)
        {
            Name = name;
            Weapon = weapon;
            MaxHealth = CalculateNewLevelValue(200);
            Health = MaxHealth;
            Dsecription = weapon.Name;
            Invetory = new Invetory(items);
            ActiveItems = new Dictionary<GearSpot, Item>();
        }
        public override void AddCrit()
        {
            Crit = 1;
        }

        public override void SetLevel(int level)
        {
            Level= level;
            MaxHealth = CalculateNewLevelValue(200);
            Health = MaxHealth;
        }

        public override void Attack(Character person)
        {
            if (Weapon != null) {
                double damage = GetDamageInRange((int)Level, (int)Weapon.Damage + (int)Level);
                damage = CheckForCritDamage(damage);
                person.RemoveHealth(damage);
                Console.WriteLine(damage);
            }
            
        }

        public override int GetDamageInRange(int min, int max) {
            Random random = new Random();
            int value = random.Next(min, max);
            return value;
        }

        public override double GetHealth() {
            return Health;
        }

        public override void IncreaseHealth(double health)
        {
            Health += health;
        }

        public override void RemoveHealth(double weaponDmg)
        {
            Health -= weaponDmg;
        }

        public override double GetLevel() {
            return Level;
        }

        public override string GetDescription() {
            return $"{Name} is level {Level}\n" +
                    $"He is equipt with items: {Dsecription}";
        }

        public override void SetWeapon(IWeapon weapon) {
           Weapon = weapon;
        }

        public override double CheckForCritDamage(double dmg) {
            
            Random gen = new Random();
            int prob = gen.Next(100);
            if (prob <= Crit)
                dmg *= 1.5;

            return dmg;
        }

        public override void AddItemToInventory(GearSpot spot,Item item) {
            Invetory.AddItem(spot, item);
        }

        public override void RemoveItemFromInventory(GearSpot spot) {
            Invetory?.RemoveItem(spot);
        }

        public override void AddItemToActiveItems(GearSpot spot, Item item) {
            ActiveItems?.Add(spot,item);
        }

        public override void RemoveItemFromActiveItems(GearSpot item) {
            ActiveItems?.Remove(item);
        }

        public override Dictionary<GearSpot,Item> GetActiveItems() {
            if (ActiveItems != null) {
                return ActiveItems;

            }
            else
                return new Dictionary<GearSpot,Item>();
        }

        public override Dictionary<GearSpot,Item> GetInventoryItems() {

            if (Invetory != null && Invetory.Items != null)
                return Invetory.Items;
            else
                return new Dictionary<GearSpot,Item>();
                
        }
    }
}
