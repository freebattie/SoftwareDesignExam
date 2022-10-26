using SoftwareDesignExam.Abstract;

namespace SoftwareDesignExam.Characters
{
    public class Player : Character
    {
        

        public Player(int health) {
            Health = health;
        }

        public override void DoDamage(Character person) {
            double weaponDmg = CheckForCritDamage();
            Math.Round(weaponDmg, 2);
            person.RemoveHealth(weaponDmg);
        }

        private double CheckForCritDamage() {
            double weaponDmg = Weapon != null ? Weapon.Damage : 0;
            Random gen = new Random();
            int prob = gen.Next(100);
            if (prob <= Crit)
                weaponDmg *= 1.5;

            return weaponDmg;
        }


        public override double GetMaxCritChance() {
            return Crit;
        }

        public override double GetUsersHealth() {
            return Health;           
        }

        //øke liv og dmg som blir gitt av spilleren jo høyere level man er 

        public override double GetUsersLevel() {
            return Level;
        }

        public override void RemoveHealth(double damage) {
            damage -= ArmorLevel;  
            Health -= damage;

        }
    }
}
