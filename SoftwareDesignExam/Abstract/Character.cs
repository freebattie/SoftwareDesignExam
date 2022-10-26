using SoftwareDesignExam.Characters;
using SoftwareDesignExam.Interface;

namespace SoftwareDesignExam.Abstract {
    public abstract class Character {
        public string Name { get; set; }

        private const double multiplayer = 0.05;

        public double Health { get => health; set => health = CalculateHealth(value); }

        private double CalculateHealth(double value) {
            return Math.Round((Level * multiplayer * value) + value, 0);
        }

        public double Level { get => level; set => level = value; }
        public double Crit { get => crit; set => crit = value; }
        public double ArmorLevel { get; set; }
        protected IWeapon Weapon { get => _weapon; private set => _weapon = value; }

        IWeapon _weapon;
        private double crit;
        private double level;
        private double health;

        public void SetWeapon(IWeapon weapon) {
            Weapon = weapon;
        }


        public abstract double GetUsersLevel();
        public abstract void RemoveHealth(double health);
        public abstract double GetUsersHealth();
        public abstract double GetMaxCritChance();
        public abstract void DoDamage(Character person);

    }
}