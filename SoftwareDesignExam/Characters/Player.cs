

using SoftwareDesignExam.Abstract;

namespace test.Characters
{
    public class Player : Character
    {

        public override void DoDamage(Character person)
        {

            double weaponDmg = Weapon != null ? Weapon.Damage : 0;
            Random gen = new Random();
            int prob = gen.Next(100);
            if (prob <= 20)
                weaponDmg *= 1.5;
            weaponDmg -= ArmorLevel;
            Math.Round(weaponDmg, 2);
            person.RemoveHealth(weaponDmg);
        }

       

        public override double GetMaxCritChance() {
            return 20;
        }

        public override double GetUsersHealth() {
            double tmpHealth = Health;
            tmpHealth *= (Level * 0.6f);

            return tmpHealth;
            
        }

        //øke liv og dmg som blir gitt av spilleren jo høyere level man er 

        public override double GetUsersLevel() {
            return 2;
        }

        public override void RemoveHealth(double damage) {

          Health -= damage;



        }
    }
}
