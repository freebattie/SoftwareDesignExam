
using Model.Decorator.Abstract;
using Model.Decorator.Original;
using Model.Interface;

namespace Model.Base.Weapons
{

    //TODO: refactor til abstract weapon?
    public class Sword : Weapon
    {
        private CharacterInfo? target;
        private Weapon? enemyWeapon;
        private int counter = 0;

        Sword() : base() {
            target = null;
            Description = "You have a 15% chance to disarm a enemy";
        }

        public override double GetDamage() {
            if (target == null) {
                CheckIfYouDisarmEnemy();

            }

            return Damage;
        }

        private void CheckIfYouDisarmEnemy() {
            if (target?.GetWeapon()?.Name?.ToLower() != "no weapon") {
                Random random = new Random();
                var chance = random.Next(100);
                if (chance <= 15) {
                    enemyWeapon = target?.GetWeapon();
                    target?.SetWeapon(new NoWeapon());
                }

            }
            else if (counter == 4) {
                if (enemyWeapon != null) {
                    target?.SetWeapon(enemyWeapon);
                    target = null;
                }
            }
            else {
                counter++;
            }
        }

        public override void SetTarget(CharacterInfo target) {
            this.target = target;
        }
    } 
}