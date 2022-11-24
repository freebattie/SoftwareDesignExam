using Model.Base.Weapons.Abstract;
using Model.Decorator.Abstract;
using Model.Interface;


namespace Model.Base.Weapons
{
    public class NoWeapon : Weapon
    {
        public NoWeapon() :base() {
            Name = "no weapon";
            Damage = 10;
        }
        public override double GetDamage() {
            return Damage;
        }

        public override void SetTarget(CharacterInfo target) {
            
        }
    }
}