using Model.Base.Player;
using Model.Interface;

namespace Model.Decorator.Abstract
{

    //TODO: Pizza
    public abstract class Character {
       
        private Weapon? _weapon;
      
        private string? dsecription;
        protected string? Dsecription { get => dsecription; set => dsecription = value; }
        public string? Name { get; set; }
       
        private double crit;
        private double level =1;
        private double health;
        private const double GAINFACTOR = 0.05;
        private double maxHealth;
        protected double MaxHealth { get => maxHealth; set => maxHealth = value; }
        protected double Level { get => level; set => level = value; }
        protected double Crit { get => CalculateNewLevelValue(crit); set => crit = value <= 100 ? value : 100; }
        protected double ArmorLevel { get; set; }
        protected Weapon? Weapon { get => _weapon; set => _weapon = value; }
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
        public abstract void SetWeapon(Weapon weapon);
        public abstract void Attack(Character person);
        public abstract void RemoveHealth(double weaponDmg);
        public abstract void IncreaseHealth(double health);
        public abstract double GetHealth();
        public abstract void SetLevel(int level);
        public abstract double GetLevel();
        public abstract void AddCrit();
        public abstract int GetDamageInRange(int min, int max);
        public abstract string GetDescription();
        public abstract string GetName();
        public abstract void SetUser(User user);
        public abstract Weapon GetWeapon();
        public abstract double GetMaxHealth();

    }
}
