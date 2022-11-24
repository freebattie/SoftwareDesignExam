using Model.Base.Player;
using Model.Base.Weapons;
using Model.Decorator.Abstract;
using Model.Base.Weapons.Abstract;
namespace Model.Decorator.Original
{
    public class StartingCharacterInfo : CharacterInfo
    {
        private double _didDmg;

        public int Topscore { get; private set; }

        public StartingCharacterInfo() { }
        public StartingCharacterInfo(User user, Weapon weapon)
        {
            Name = user.Name;
            Level = user.Level;
            Topscore = user.Topscore;
            Weapon = weapon;
            MaxHealth = CalculateNewLevelValue(200);
            Health = MaxHealth;
            Dsecription = weapon.Name;


        }
        public override void AddCrit()
        {
            Crit = 1;
        }

        public override void SetLevel(int level)
        {
            Level = level;
            MaxHealth = CalculateNewLevelValue(200);
            Health = MaxHealth;
        }

        public override void Attack(CharacterInfo person)
        {
            if (Weapon != null)
            {
                double damage = GetDamageInRange(25+(int)Level, (int)GetWeapon().GetDamage() + (int)Level);
                damage = CheckForCritDamage(damage);
                person.RemoveHealth(damage);
                _didDmg = damage;
                Console.WriteLine(damage);
            }

        }

        public override int GetDamageInRange(int min, int max)
        {
            Random random = new Random();
            int value = random.Next(min, max);
            return value;
        }

        public override double GetHealth() => Health;
        public override void IncreaseHealth(double health) => Health += health;
        public override void RemoveHealth(double weaponDmg) => Health -= weaponDmg;
        public override double GetLevel() => Level;

        public override string GetDescription()
        {
            return "\n# A Backpack";

        }

        public override void SetWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }

        public override double CheckForCritDamage(double dmg)
        {

            Random gen = new Random();
            int prob = gen.Next(100);
            if (prob <= Crit)
                dmg *= 1.5;

            return dmg;
        }







        public override string GetName()
        {
            return Name != null ? Name : "";
        }

        public override void SetUser(User user)
        {
            SetName(user.Name);
            SetLevel(user.Level);


        }

        public override Weapon GetWeapon() {
            return Weapon != null ? Weapon : new NoWeapon();
        }

        public override double GetMaxHealth() {
            return MaxHealth;
        }

        public override void SetName(string name) {
            Name = name;
        }

        public override int GetCrit() {
            return (int)Crit;
        }

        public override int GetMaxDamage() {
            var maxdmg = (int)GetWeapon().GetDamage() * 1.5;
            return (int)maxdmg;
        }

        public override int GetDamageDone() {
            return (int)_didDmg;
        }
    }
}
