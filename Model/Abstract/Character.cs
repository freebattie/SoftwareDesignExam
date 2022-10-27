using Model.Characters;
using Model.Base;
using Model.Interface;
using System.Collections;
using Model.Decorator.ConcreateDecrators;

using Model.Enums;
using Model.Factory;

namespace Model.Abstract {
    public abstract class Character {
       
        IWeapon _weapon;
        private double crit;
        private double level;
        private double health;
        private const double GAINFACTOR = 0.05;
        List<GearItems> items = new();

        protected string? Name { get; set; }
        public double Health { get => CalculateHealth(health); protected set => health = CalculateHealth(value); }
        protected double Level { get => level; set => level = value; }
        protected double Crit { get => crit; set => crit = value; }
        protected double ArmorLevel { get; set; }
        protected int Score { get; set; }
        //TODO: se på 
        protected IWeapon Weapon { get => _weapon; private set => _weapon = value; }

        public void AddItem(GearItems item) {
            items.Add(item);
        }
        public void CalculateItemStats() {
            Item gear = new GearSlot();
            gear = ItemFactory.GetDecoratorItem(items, gear);
            Health += gear.GetHealth();
            _weapon.Damage += gear.GetDamage();
            Console.WriteLine(gear.GetDescription());
        }
        private double CalculateHealth(double value) {
            return Math.Round((Level * GAINFACTOR * value) + value, 0);
            
        }
        public void SetWeapon(IWeapon weapon) {
            Weapon = weapon;
        }
        public  void DoDamage(Character person) {
            double weaponDmg = CheckForCritDamage();
            Math.Round(weaponDmg, 2);
            person.RemoveHealth(weaponDmg);
        }
        public  void RemoveHealth(double weaponDmg) {
            Health -= weaponDmg;
        }
        private double CheckForCritDamage() {
            double weaponDmg = Weapon != null ? Weapon.Damage : 0;
            Random gen = new Random();
            int prob = gen.Next(100);
            if (prob <= Crit)
                weaponDmg *= 1.5;

            return weaponDmg;
        }

    }
}