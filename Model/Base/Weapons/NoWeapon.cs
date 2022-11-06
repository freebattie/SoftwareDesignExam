
using Model.Interface;


namespace Model.Base.Weapons
{
    public class NoWeapon : Weapon
    {

        public override double GetDamage() {
            return Damage;
        }
    }
}