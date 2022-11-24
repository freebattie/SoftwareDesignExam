using Model.Base.Weapons.Abstract;
using Model.Decorator.Abstract;
using Model.Decorator.Original;

namespace Model.Base.Weapons
{
    internal class GoldSword :Weapon {

        #region private fileds
        private CharacterInfo? _target;
        private Weapon? _enemyWeapon;
        private int _counter = 0;
        #endregion


        #region constructors
        public GoldSword() : base() {
            _target = new StartingCharacterInfo();
            Description = "You have a 100% chance to disarm a enemy";
        }
        #endregion

        #region overrides methods
        public override double GetDamage() {
            CheckIfYouDisarmEnemy();
            return Damage;
        }

        private void CheckIfYouDisarmEnemy() {
            if (_counter == 0) {
                Random random = new Random();
                var chance = random.Next(100);
                if (chance <= 101) {
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

        public override void SetTarget(CharacterInfo target) {
            this._target = target;
        }
        #endregion
    }
}

