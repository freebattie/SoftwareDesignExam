using Model.Base.Player;
using Model.Decorator.Abstract;
using Model.Base.Weapons.Abstract;

namespace Model.Decorator
{

    //TODO: PizzaDecorator
    public class CharacterInfoDecorator : CharacterInfo {
        private readonly CharacterInfo original;

        public CharacterInfoDecorator(CharacterInfo original) {
            this.original = original;
        }
        public override void AddCrit() {
            original.AddCrit();
        }
        public override void Attack(CharacterInfo person) {
            original.Attack(person);
        }

        public override int GetDamageInRange(int min, int max) {
           return original.GetDamageInRange(min, max);
        }

        public override string GetDescription() {
            return original.GetDescription();
        }

        public override double GetHealth() {
            return original.GetHealth();
        }

        public override double GetLevel() {
            return original.GetLevel();
        }

        public override void IncreaseHealth(double health) {
            original.IncreaseHealth(health);
        }

        public override void RemoveHealth(double weaponDmg) {
            original.RemoveHealth(weaponDmg);
        }

        public override void SetLevel(int level) {
            original.SetLevel(level);
        }

        public override void SetWeapon(Weapon weapon) {
           original.SetWeapon(weapon);
        }

        public override double CheckForCritDamage(double dmg) {
            return original.CheckForCritDamage(dmg);
        }
        public override string GetName() {
           return original.GetName();
        }

        public override void SetUser(User user) {
            original.SetUser(user);
        }

        public override Weapon GetWeapon() {
           return  original.GetWeapon();
        }

        public override double GetMaxHealth() {
            return original.GetMaxHealth();
        }

        public override void SetName(string name) {
             original.SetName(name);

        }

        public override int GetCrit() {
            return original.GetCrit();
        }

        public override int GetMaxDamage() {
           return original.GetMaxDamage();    
        }

        public override int GetDamageDone() {
            return original.GetDamageDone();
        }
    }
}
