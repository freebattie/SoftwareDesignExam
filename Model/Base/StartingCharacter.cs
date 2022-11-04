
using Model.Abstract;
using Model.Enums;
using Model.Interface;
using Persistence.Db;

namespace Model.Base
{
    public class StartingCharacter : Character
    {
        public StartingCharacter() { }
        public StartingCharacter(User user,IWeapon weapon,Dictionary<GearSpot,Item> items)
        {
            Name = user.Name;
            Level = user.Level;
            Topscore = user.Topscore;
            Weapon = weapon;
            MaxHealth = CalculateNewLevelValue(200);
            Health = MaxHealth;
            Dsecription = weapon.Name;
           
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

        public override double GetHealth() => Health;
        public override void IncreaseHealth(double health) => Health += health;
        public override void RemoveHealth(double weaponDmg) => Health -= weaponDmg;
        public override double GetLevel() => Level;

        public override string GetDescription() {
            return "";
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

       

        public override void AddItemToActiveItems(GearSpot spot, Item item) {
            ActiveItems?.Add(spot,item);
        }

        public override void RemoveItemFromActiveItems(GearSpot item) {
            ActiveItems?.Remove(item);
        }

        public override List<Item> GetActiveItems() {
            var list = new List<Item>();
            foreach (var item in ActiveItems.Values) {
                list.Add(item);
                item.
            }
            return list;
        }

      

        public override string GetName() {
            return Name;
        }
    }
}
