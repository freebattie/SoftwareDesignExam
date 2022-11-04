﻿using Model.Base;
using Model.Enums;

using Model.Interface;
using System.Reflection.Emit;

namespace Model.Abstract {

    //TODO: Pizza
    public abstract class Character {
       
        private IWeapon? _weapon;
        public Invetory? Invetory { get;protected set; }
        public Dictionary<GearSpot,Item>? ActiveItems { get; set; }
        private string? dsecription;
        protected string? Dsecription { get => dsecription; set => dsecription = value; }
        public string? Name { get; set; }
        public int Topscore { get; set; }
        private double crit;
        private double level =1;
        private double health;
        private const double GAINFACTOR = 0.05;
        private double maxHealth;
        protected double MaxHealth { get => maxHealth; set => maxHealth = value; }
        protected double Level { get => level; set => level = value; }
        protected double Crit { get => CalculateNewLevelValue(crit); set => crit = value <= 100 ? value : 100; }
        protected double ArmorLevel { get; set; }
        protected int Score { get; set; }
        protected IWeapon? Weapon { get => _weapon; set => _weapon = value; }
        protected double Health {
            get { return health; }
            set {
                if (value <= MaxHealth) {
                    health = value;
                }
                else {
                    health = MaxHealth;
                }
            }
        }

        protected double CalculateNewLevelValue(double value) {
            return Math.Round((Level * GAINFACTOR * value) + value, 0);
        }
        
        public abstract double CheckForCritDamage(double dmg);
        public abstract void SetWeapon(IWeapon weapon);
        public abstract void Attack(Character person);
        public abstract void RemoveHealth(double weaponDmg);
        public abstract void IncreaseHealth(double health);
        public abstract double GetHealth();
        public abstract void SetLevel(int level);
        public abstract double GetLevel();
        public abstract void AddCrit();
        public abstract int GetDamageInRange(int min, int max);
        public abstract string GetDescription();
        public abstract void AddItemToInventory(GearSpot spot, Item item);
        public abstract void RemoveItemFromInventory(GearSpot spot);
        public abstract void AddItemToActiveItems(GearSpot spot,Item  item);
        public abstract void RemoveItemFromActiveItems(GearSpot spot);
        public abstract List<Item> GetActiveItems();
        public abstract void MoveFromInvetoryToActiveItem(GearSpot spot);
        public abstract Dictionary<GearSpot,Item> GetInventoryItems();
        public abstract Item GetInventoryItem(GearSpot spot);
        public abstract string GetName();

    }
}
