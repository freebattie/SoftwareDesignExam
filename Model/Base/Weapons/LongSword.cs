
using Model.Base.Weapons.Abstract;
using Model.Decorator.Abstract;

namespace Model.Base.Weapons
{

    //TODO: refactor til abstract weapon?
    public class LongSword : Weapon
    {
        #region private fileds
        private CharacterInfo? _target;
        private Weapon? _enemyWeapon;
        private int _counter = 0;
        #endregion

        #region constructor
        public LongSword() : base() {
            _target = null;
            Description = "You have a 100% chance to disarm a enemy";
        }
        #endregion

        #region overrides
        public override double GetDamage() {
            if (_target == null) {
                CheckIfYouDisarmEnemy();

            }

            return Damage;
        }
       

        public override void SetTarget(CharacterInfo target) {
            this._target = target;
        }
        #endregion

        #region private methods
        private void CheckIfYouDisarmEnemy() {
            if (_counter == 0) {
                Random random = new Random();
                var chance = random.Next(100);
                if (chance <= 100) {
                    _enemyWeapon = _target?.GetWeapon();
                    _target?.SetWeapon(new NoWeapon());
                }

            }
            else if (_counter == 4) {
                if (_enemyWeapon != null) {
                    _target?.SetWeapon(_enemyWeapon);
                    _target = null;
                    _counter = 0;
                }
            }
            else {
                _counter++;
            }
        }
        #endregion
    }
}