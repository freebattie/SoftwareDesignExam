
using Model.Abstract;

namespace Model.Base
{
    public class Level1Player : Character
    {

        public Level1Player()
        {
            Name = "";
            
            MaxHealth = CalculateNewLevelValue(200);
            Health = MaxHealth;
        }
        public override void AddCrit()
        {
            Crit = 1;
        }

        public override void AddLevel()
        {
            Level++;
        }

        public override void Attack(Character person)
        {
            Random random = new Random();
            int value = random.Next((int)Level, (int)Weapon.Damage);
            person.RemoveHealth(value);
            Console.WriteLine(value);
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
    }
}
