using Model.Base;

using Model.Interface;


namespace Model.Abstract {
    public abstract class Character {
        private IWeapon _weapon;
        private double crit;
        private double level =1;
        private double health;
        private const double GAINFACTOR = 0.05;
        
        private double maxHealth;
        protected string? Name { get; set; }
       

        protected Character() {
            Name = "";
            
            MaxHealth = CalculateNewLevelValue(200);
            Health = MaxHealth;
        }

        protected double Level { get => level; set => level = value; }
        protected double Crit { get => CalculateNewLevelValue(crit); set => crit = value <= 100 ? value : 100; }
        protected double ArmorLevel { get; set; }
        protected int Score { get; set; }
        protected IWeapon Weapon { get => _weapon;  set => _weapon = value; }
       

        public double Health {
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

        protected double MaxHealth { get => maxHealth; set => maxHealth = value; }

        protected double CalculateNewLevelValue(double value) {
            return Math.Round((Level * GAINFACTOR * value) + value, 0);

        }
        protected double CheckForCritDamage() {
            double weaponDmg = Weapon != null ? Weapon.Damage : 0;
            Random gen = new Random();
            int prob = gen.Next(100);
            if (prob <= Crit)
                weaponDmg *= 1.5;

            return weaponDmg;
        }

        public void SetWeapon(IWeapon weapon) {
            Weapon = weapon;

        }
        public abstract void Attack(Character person);


        public abstract void RemoveHealth(double weaponDmg);
        public abstract void IncreaseHealth(double health);
        public abstract double GetHealth();
        public abstract void AddLevel();
        public abstract void AddCrit();

    }
}
