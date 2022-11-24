
using Model.Base.Weapons.Abstract;
using Model.Decorator.Abstract;

namespace Model.Base.Weapons
{

    //TODO: refactor til abstract weapon?
    public class Sword : Weapon
    {
        private CharacterInfo? _target;
        private Weapon? _enemyWeapon;
        private int _counter = 0;

        public Sword() : base() {
            _target = null;
            Description = "You have a 15% chance to disarm a enemy";
        }

        public override double GetDamage() {
            if (_target == null) {
                CheckIfYouDisarmEnemy();

            }

            return Damage;
        }

        private void CheckIfYouDisarmEnemy() {
            if (_counter == 0) {
                Random random = new Random();
                var chance = random.Next(100);
                if (chance <= 15) {
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
    } 
}