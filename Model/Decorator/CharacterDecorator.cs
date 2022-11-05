

using Model.Base.Player;
using Model.Decorator.Abstract;
using Model.Interface;

namespace Model.Decorator
{

    //TODO: PizzaDecorator
    public class CharacterDecorator : Character {
        private readonly Character original;

        public CharacterDecorator(Character original) {
            this.original = original;
        }
        public override void AddCrit() {
            original.AddCrit();
        }
        public override void Attack(Character person) {
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

        public override void SetWeapon(IWeapon weapon) {
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

        public override IWeapon GetWeapon() {
           return  original.GetWeapon();
        }

        public override double GetMaxHealth() {
            return original.GetMaxHealth();
        }
    }
}
