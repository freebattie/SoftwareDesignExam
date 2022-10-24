using SoftwareDesignExam.Characters;
using SoftwareDesignExam.Interface;

namespace SoftwareDesignExam.Abstract {
    public abstract class Character
    {
        public string Name { get; set; }
        public double Health { get; set; }
        public double Level { get; set; }
        public double Crit { get; set; }
        public double ArmorLevel { get; set; }
        protected IWeapon Weapon { get => _weapon; private set => _weapon = value; }

        IWeapon _weapon;

        public void SetWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }


        public abstract double GetUsersLevel();
        public abstract void RemoveHealth(double health);
        public abstract double GetUsersHealth();
        public abstract double GetMaxCritChance();
        public abstract void DoDamage(Character person);

    }
}