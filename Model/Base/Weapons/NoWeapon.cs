
using Model.Decorator.Abstract;
using Model.Interface;


namespace Model.Base.Weapons
{
    public class NoWeapon : Weapon
    {
        public NoWeapon() :base() {
            Name = "no weapon";
        }
        public override double GetDamage() {
            return Damage;
        }

        public override void SetTarget(CharacterInfo target) {
            
        }
    }
}