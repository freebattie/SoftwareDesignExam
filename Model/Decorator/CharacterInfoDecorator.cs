using Model.Base.Player;
using Model.Decorator.Abstract;
using Model.Base.Weapons.Abstract;

namespace Model.Decorator
{

    /// <summary>
    /// Dekoratoren
    /// </summary>
    public class CharacterInfoDecorator : CharacterInfo {
        private readonly CharacterInfo _original;

        #region public methods
        public CharacterInfoDecorator(CharacterInfo original) {
            _original = original;
        }
        public override void AddCrit() {
            _original.AddCrit();
        }
        public override void Attack(CharacterInfo person) {
            _original.Attack(person);
        }

        public override int GetDamageInRange(int min, int max) {
           return _original.GetDamageInRange(min, max);
        }

        public override string GetDescription() {
            return _original.GetDescription();
        }

        public override double GetHealth() {
            return _original.GetHealth();
        }

        public override double GetLevel() {
            return _original.GetLevel();
        }

        public override void IncreaseHealth(double health) {
            _original.IncreaseHealth(health);
        }

        public override void RemoveHealth(double weaponDmg) {
            _original.RemoveHealth(weaponDmg);
        }

        public override void SetLevel(int level) {
            _original.SetLevel(level);
        }

        public override void SetWeapon(Weapon weapon) {
           _original.SetWeapon(weapon);
        }

        public override double CheckForCritDamage(double dmg) {
            return _original.CheckForCritDamage(dmg);
        }
        public override string GetName() {
           return _original.GetName();
        }

        public override void SetUser(User user) {
            _original.SetUser(user);
        }

        public override Weapon GetWeapon() {
           return  _original.GetWeapon();
        }

        public override double GetMaxHealth() {
            return _original.GetMaxHealth();
        }

        public override void SetName(string name) {
             _original.SetName(name);

        }

        public override int GetCrit() {
            return _original.GetCrit();
        }

        public override int GetMaxDamage() {
           return _original.GetMaxDamage();    
        }

        public override int GetDamageDone() {
            return _original.GetDamageDone();
        }
        #endregion
    }
}
